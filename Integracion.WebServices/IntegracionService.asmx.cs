using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Integracion.Datos;

namespace Integracion.API
{
    /// <summary>
    /// Servicio de Integración para el sistema de Auto Adornos.
    /// Actua como puente entre los canales (Web/Caja) y el CORE.
    /// </summary>
    [WebService(Namespace = "http://autoadornos.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class IntegracionService : System.Web.Services.WebService
    {
        private DB_IntegracionEntities dbLocal = new DB_IntegracionEntities();

        private void GuardarLog(string servicio, string parametros, string respuesta)
        {
            try
            {
                tblLogServicio nuevoLog = new tblLogServicio
                {
                    Servicio = servicio,
                    Parametros = parametros,
                    Respuesta = respuesta,
                    Fecha = DateTime.Now
                };
                dbLocal.tblLogServicios.Add(nuevoLog);
                dbLocal.SaveChanges();
            }
            catch
            {
                // En logs, si falla la escritura no bloqueamos el proceso principal
            }
        }


        [WebMethod(Description = "Obtiene el catálogo. Si el CORE falla, usa el Cache local.")]
        public List<Cache_tblProducto> ListarProductos()
        {
            try
            {
                WebServices.CoreReferencia.CoreServiceSoapClient clienteCore = new WebServices.CoreReferencia.CoreServiceSoapClient();


                var productosCore = clienteCore.ListarProductos();


                dbLocal.Database.ExecuteSqlCommand("TRUNCATE TABLE Cache_tblProducto");


                foreach (var prod in productosCore)
                {
                    dbLocal.Cache_tblProducto.Add(new Cache_tblProducto
                    {
                        IdProducto = prod.IdProducto,
                        Codigo = prod.Codigo,
                        Descripcion = prod.Descripcion,
                        Precio = prod.Precio,
                        Existencia = prod.Existencia
                    });
                }
                dbLocal.SaveChanges(); 

                GuardarLog("ListarProductos", "N/A", "Exito: Datos obtenidos del CORE y caché actualizado.");


                return dbLocal.Cache_tblProducto.ToList();
            }
            catch (Exception ex)
            {
                GuardarLog("ListarProductos", "N/A", "MODO OFFLINE - Error CORE: " + ex.Message);
                return dbLocal.Cache_tblProducto.ToList();
            }
        }

        [WebMethod(Description = "Valida el acceso del usuario contra el CORE.")]
        public bool ValidarUsuario(string usuario, string clave)
        {
            try
            {
                WebServices.CoreReferencia.CoreServiceSoapClient clienteCore = new WebServices.CoreReferencia.CoreServiceSoapClient();

                var result = clienteCore.ValidarUsuario(usuario, clave);

                return result != null;
            }
            catch (Exception ex)
            {
                GuardarLog("ValidarUsuario", usuario, "Error CORE: " + ex.Message);
                return false;
            }
        }


        [WebMethod(Description = "Envía la factura al CORE. Si falla, la guarda completa en la cola local.")]
        public string RegistrarVenta(int idCliente, int idVehiculo, int idUsuario, int idSucursal, string canalVenta, decimal total, List<ItemVenta> detalles)
        {
            string paramsInfo = $"Cliente: {idCliente}, Sucursal: {idSucursal}, Canal: {canalVenta}";

            // Calculamos el ITBIS aqui mismo
            decimal subtotalReal = total / 1.18m;
            decimal impuestoReal = total - subtotalReal;

            try
            {

                WebServices.CoreReferencia.CoreServiceSoapClient clienteCore = new WebServices.CoreReferencia.CoreServiceSoapClient();

                int idFacturaCore = clienteCore.InsertarFacturaPrueba(
                    idCliente,
                    idVehiculo,
                    idUsuario,
                    idSucursal,
                    canalVenta,
                    subtotalReal,
                    impuestoReal,
                    total
                );

                if (detalles != null)
                {
                    foreach (var item in detalles)
                    {
                        if (item.IdProducto.HasValue)
                        {
                            clienteCore.InsertarFacturaDetalleProductoPrueba(idFacturaCore, item.IdProducto.Value, item.Cantidad, item.Precio);
                            clienteCore.RegistrarMovimientoInventario(item.IdProducto.Value, idSucursal, "SALIDA", item.Cantidad, "Venta Integración", idUsuario);
                        }
                        else if (item.IdServicio.HasValue)
                        {
                            clienteCore.InsertarFacturaDetalleServicioPrueba(idFacturaCore, item.IdServicio.Value, item.Cantidad, item.Precio);
                        }
                    }
                }

                GuardarLog("RegistrarVenta", paramsInfo, "Exito: Sincronizado con el CORE.");
                return "Venta procesada correctamente en el servidor central.";
            }
            catch (Exception ex)
            {
                try
                {
                    Cola_tblFactura facturaLocal = new Cola_tblFactura
                    {
                        IdCliente = idCliente,
                        IdVehiculo = idVehiculo,
                        IdUsuario = idUsuario,
                        IdSucursal = idSucursal,
                        CanalVenta = canalVenta,
                        Subtotal = subtotalReal,
                        Impuesto = impuestoReal,
                        Total = total,
                        Fecha = DateTime.Now,
                        Sincronizado = false
                    };
                    dbLocal.Cola_tblFactura.Add(facturaLocal);
                    dbLocal.SaveChanges();

                    // 2. Guardamos Detalle local
                    if (detalles != null)
                    {
                        foreach (var item in detalles)
                        {
                            Cola_tblFacturaDetalle det = new Cola_tblFacturaDetalle
                            {
                                IdFacturaLocal = facturaLocal.IdFacturaLocal,
                                IdProducto = item.IdProducto,
                                IdServicio = item.IdServicio,
                                Cantidad = item.Cantidad,
                                Precio = item.Precio,
                                Importe = item.Cantidad * item.Precio
                            };
                            dbLocal.Cola_tblFacturaDetalle.Add(det);
                        }
                        dbLocal.SaveChanges();
                    }

                    GuardarLog("RegistrarVenta", paramsInfo, "CORE CAIDO - Venta guardada en Cola Local.");
                    //return "El servidor central no responde. Venta guardada localmente para sincronización posterior.";
                    return "Error CORE: " + ex.Message + " --- Inner: " + (ex.InnerException != null ? ex.InnerException.Message : "");
                }
                catch (Exception localEx)
                {
                    GuardarLog("RegistrarVenta", paramsInfo, "ERROR LOCAL: " + localEx.Message);
                    return "Error al procesar la venta localmente.";
                }
            }
        }

        [WebMethod(Description = "Sincroniza las ventas guardadas localmente hacia el CORE.")]
        public string SincronizarVentasOffline()
        {
            try
            {
                // 1. Verificamos si el CORE ya despertó
                WebServices.CoreReferencia.CoreServiceSoapClient clienteCore = new WebServices.CoreReferencia.CoreServiceSoapClient();
                var pruebaConexion = clienteCore.ListarProductos();

                if (pruebaConexion != null)
                {
                    // 2. Buscar facturas que están atrapadas en la Cola Local
                    // El 'false' o '0' significa que no han subido al Core
                    var facturasPendientes = dbLocal.Cola_tblFactura.Where(f => f.Sincronizado == false).ToList();

                    if (facturasPendientes.Count == 0)
                    {
                        return "No hay ventas en modo Offline pendientes por sincronizar.";
                    }

                    int contadorExito = 0;

                    // 3. Recorremos cada factura atrapada y la subimos al Core
                    foreach (var factura in facturasPendientes)
                    {
                        try
                        {
                            // A. Insertar cabecera de la factura en el CORE
                            int idFacturaCore = clienteCore.InsertarFacturaPrueba(
                                factura.IdCliente ?? 1,
                                factura.IdVehiculo ?? 1,
                                factura.IdUsuario ?? 1,
                                factura.IdSucursal ?? 1,
                                factura.CanalVenta,
                                factura.Subtotal ?? 0,
                                factura.Impuesto ?? 0,
                                factura.Total ?? 0
                            );

                            // B. Buscar los artículos (detalles) de esta factura específica en la cola
                            var detalles = dbLocal.Cola_tblFacturaDetalle.Where(d => d.IdFacturaLocal == factura.IdFacturaLocal).ToList();

                            // C. Insertar cada artículo en el CORE y descontar el inventario real
                            foreach (var item in detalles)
                            {
                                if (item.IdProducto.HasValue)
                                {
                                    clienteCore.InsertarFacturaDetalleProductoPrueba(idFacturaCore, item.IdProducto.Value, item.Cantidad ?? 0, item.Precio ?? 0);
                                    clienteCore.RegistrarMovimientoInventario(item.IdProducto.Value, factura.IdSucursal ?? 1, "SALIDA", item.Cantidad ?? 0, "Sincronización Offline", factura.IdUsuario ?? 1);
                                }
                                else if (item.IdServicio.HasValue)
                                {
                                    clienteCore.InsertarFacturaDetalleServicioPrueba(idFacturaCore, item.IdServicio.Value, item.Cantidad ?? 0, item.Precio ?? 0);
                                }
                            }

                            // D. ¡ÉXITO! Marcamos la factura local como "Sincronizada" para que no se vuelva a subir mañana
                            factura.Sincronizado = true;
                            dbLocal.SaveChanges();

                            contadorExito++;
                        }
                        catch (Exception exSync)
                        {
                            GuardarLog("SincronizarVentasOffline", $"FacturaLocal: {factura.IdFacturaLocal}", "Error al subir una factura: " + exSync.Message);
                            // Si falla una sola factura, no detenemos el proceso. Dejamos que intente subir las demás.
                        }
                    }

                    GuardarLog("SincronizarVentasOffline", "Sistema", $"Se sincronizaron {contadorExito} facturas con éxito.");
                    return $"Sincronización completada. Se recuperaron y subieron {contadorExito} facturas al servidor central.";
                }
                else
                {
                    return "El servidor central aún no responde. Intente más tarde.";
                }
            }
            catch (Exception ex)
            {
                GuardarLog("SincronizarVentasOffline", "Sistema", "Error Crítico: " + ex.Message);
                return "Error en la sincronización: No se pudo conectar con el CORE.";
            }
        }

        [WebMethod(Description = "Busca un cliente por su cédula o RNC.")]
        public WebServices.CoreReferencia.sp_BuscarClientePorCedulaRNC_Result BuscarClientePorCedulaRNC(string cedula)
        {
            try
            {
                // Conectamos con el CORE real
                WebServices.CoreReferencia.CoreServiceSoapClient clienteCore = new WebServices.CoreReferencia.CoreServiceSoapClient();
                var cliente = clienteCore.BuscarClientePorCedulaRNC(cedula);

                return cliente;
            }
            catch (Exception ex)
            {
                GuardarLog("BuscarClientePorCedulaRNC", cedula, "Error CORE: " + ex.Message);
                return null;
            }
        }

        [WebMethod(Description = "Registra un nuevo cliente en el servidor central.")]
        public string InsertarCliente(string nombre, string cedulaRNC, string telefono, string direccion, string email)
        {
            try
            {
                WebServices.CoreReferencia.CoreServiceSoapClient clienteCore = new WebServices.CoreReferencia.CoreServiceSoapClient();

                // Llamamos al Core para que inserte el cliente
                // Nota: Le paso "false" al final asumiendo que es el campo EsAnonimo (0)
                clienteCore.InsertarCliente(nombre, cedulaRNC, telefono, direccion, email, false);

                GuardarLog("InsertarCliente", cedulaRNC, "Exito: Cliente creado en el CORE.");
                return "OK";
            }
            catch (Exception ex)
            {
                GuardarLog("InsertarCliente", cedulaRNC, "Error CORE: " + ex.Message);
                return "Error al registrar cliente: " + ex.Message;
            }
        }



        [WebMethod(Description = "Trae los vehículos de un cliente.")]
        public List<VehiculoWeb> ListarVehiculosCliente(int idCliente)
        {
            try
            {
                var clienteCore = new WebServices.CoreReferencia.CoreServiceSoapClient();
                // Asumimos que el Core tiene este método habilitado
                var listaCore = clienteCore.ListarVehiculosPorCliente(idCliente);
                var listaWeb = new List<VehiculoWeb>();

                foreach (var v in listaCore)
                {
                    listaWeb.Add(new VehiculoWeb
                    {
                        IdVehiculo = v.IdVehiculo,
                        Marca = v.Marca,
                        Modelo = v.Modelo,
                        Placa = v.Placa,
                        Anio = v.Anio.HasValue ? v.Anio.Value.ToString() : "N/A"
                    });
                }
                return listaWeb;
            }
            catch (Exception)
            {
                return new List<VehiculoWeb>(); // Retorna vacío si hay error o está offline
            }
        }

        [WebMethod(Description = "Registra un vehículo a un cliente existente.")]
        public string InsertarVehiculo(int idCliente, string marca, string modelo, string anio, string placa, string color)
        {
            try
            {
                int anioVehiculo = 0;
                int.TryParse(anio, out anioVehiculo);

                var clienteCore = new WebServices.CoreReferencia.CoreServiceSoapClient();

                clienteCore.InsertarVehiculo(idCliente, marca, modelo, anioVehiculo, placa, color);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Error al guardar vehículo: " + ex.Message;
            }
        }
    }

    public class ItemVenta
    {
        public int? IdProducto { get; set; }
        public int? IdServicio { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }

    public class VehiculoWeb
    {
        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Anio { get; set; }
        public string Placa { get; set; }
        public string Display => Marca + " " + Modelo + " - Placa: " + Placa;
    }


}