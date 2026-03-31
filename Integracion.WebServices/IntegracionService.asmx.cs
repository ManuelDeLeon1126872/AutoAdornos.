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

                GuardarLog("ListarProductos", "N/A", "Exito: Datos obtenidos del CORE.");

                return dbLocal.Cache_tblProducto.ToList();
            }
            catch (Exception ex)
            {
                GuardarLog("ListarProductos", "N/A", "MODO OFFLINE - Error CORE: " + ex.Message);
                return dbLocal.Cache_tblProducto.ToList();
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
                    return "El servidor central no responde. Venta guardada localmente para sincronización posterior.";
                }
                catch (Exception localEx)
                {
                    GuardarLog("RegistrarVenta", paramsInfo, "ERROR LOCAL: " + localEx.Message);
                    return "Error al procesar la venta localmente.";
                }
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
}