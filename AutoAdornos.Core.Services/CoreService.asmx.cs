using System;
using System.Collections.Generic;
using System.Web.Services;
using log4net;
using AutoAdornos.Core.Business.Seguridad;
using AutoAdornos.Core.Business.Clientes;
using AutoAdornos.Core.Business.Vehiculos;
using AutoAdornos.Core.Business.Catalogos;
using AutoAdornos.Core.Business.Facturacion;
using AutoAdornos.Core.Business.Inventario;
using AutoAdornos.Core.Business.Auditoria;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class CoreService : WebService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CoreService));

        private void RegistrarLogServicio(string servicio, string parametros, string respuesta)
        {
            try
            {
                AuditoriaBL bl = new AuditoriaBL();
                bl.InsertarLogServicio(servicio, parametros, respuesta);
            }
            catch (Exception ex)
            {
                log.Error("Error registrando log de servicio en BD", ex);
            }
        }

        private void RegistrarAuditoria(int idUsuario, string modulo, string accion, string descripcion)
        {
            try
            {
                AuditoriaBL bl = new AuditoriaBL();
                bl.InsertarAuditoria(idUsuario, modulo, accion, descripcion);
            }
            catch (Exception ex)
            {
                log.Error("Error registrando auditoría en BD", ex);
            }
        }

        [WebMethod]
        public sp_ValidarUsuario_Result ValidarUsuario(string nombreUsuario, string clave)
        {
            string servicio = "ValidarUsuario";
            string parametros = $"nombreUsuario={nombreUsuario}";

            try
            {
                UsuarioBL bl = new UsuarioBL();
                var resultado = bl.ValidarUsuario(nombreUsuario, clave);

                if (resultado != null)
                {
                    log.Info($"Usuario validado correctamente: {nombreUsuario}");
                    RegistrarLogServicio(servicio, parametros, "OK - Usuario válido");
                    RegistrarAuditoria(resultado.IdUsuario, "SEGURIDAD", "LOGIN", $"Inicio de sesión de {nombreUsuario}");
                }
                else
                {
                    log.Warn($"Intento de login fallido: {nombreUsuario}");
                    RegistrarLogServicio(servicio, parametros, "WARN - Usuario inválido");
                }

                return resultado;
            }
            catch (Exception ex)
            {
                log.Error($"Error en {servicio}", ex);
                RegistrarLogServicio(servicio, parametros, $"ERROR - {ex.Message}");
                throw;
            }
        }

        [WebMethod]
        public List<sp_ListarProductos_Result> ListarProductos()
        {
            string servicio = "ListarProductos";
            string parametros = "Sin parámetros";

            try
            {
                ProductoBL bl = new ProductoBL();
                var resultado = bl.ListarProductos();

                log.Info($"{servicio} ejecutado correctamente. Total registros: {resultado.Count}");
                RegistrarLogServicio(servicio, parametros, $"OK - {resultado.Count} productos");

                return resultado;
            }
            catch (Exception ex)
            {
                log.Error($"Error en {servicio}", ex);
                RegistrarLogServicio(servicio, parametros, $"ERROR - {ex.Message}");
                throw;
            }
        }

        [WebMethod]
        public List<sp_ListarServicios_Result> ListarServicios()
        {
            ServicioBL bl = new ServicioBL();
            return bl.ListarServicios();
        }

        [WebMethod]
        public List<sp_ListarSucursales_Result> ListarSucursales()
        {
            SucursalBL bl = new SucursalBL();
            return bl.ListarSucursales();
        }

        [WebMethod]
        public List<sp_ListarClientes_Result> ListarClientes()
        {
            ClienteBL bl = new ClienteBL();
            return bl.ListarClientes();
        }

        [WebMethod]
        public sp_BuscarClientePorCedulaRNC_Result BuscarClientePorCedulaRNC(string cedulaRnc)
        {
            ClienteBL bl = new ClienteBL();
            return bl.BuscarClientePorCedulaRNC(cedulaRnc);
        }

        [WebMethod]
        public int InsertarCliente(string nombre, string cedulaRnc, string telefono, string direccion, string email, bool esAnonimo)
        {
            string servicio = "InsertarCliente";
            string parametros = $"nombre={nombre}, cedulaRnc={cedulaRnc}, telefono={telefono}";

            try
            {
                ClienteBL bl = new ClienteBL();
                int idCliente = bl.InsertarCliente(nombre, cedulaRnc, telefono, direccion, email, esAnonimo);

                log.Info($"Cliente insertado correctamente. IdCliente={idCliente}");
                RegistrarLogServicio(servicio, parametros, $"OK - IdCliente={idCliente}");

                return idCliente;
            }
            catch (Exception ex)
            {
                log.Error($"Error en {servicio}", ex);
                RegistrarLogServicio(servicio, parametros, $"ERROR - {ex.Message}");
                throw;
            }
        }

        [WebMethod]
        public List<sp_ListarVehiculosPorCliente_Result> ListarVehiculosPorCliente(int idCliente)
        {
            VehiculoBL bl = new VehiculoBL();
            return bl.ListarVehiculosPorCliente(idCliente);
        }

        [WebMethod]
        public int InsertarVehiculoPrueba(int idCliente, string marca, string modelo, int anio, string placa, string color)
        {
            string servicio = "InsertarVehiculoPrueba";
            string parametros = $"idCliente={idCliente}, marca={marca}, modelo={modelo}, anio={anio}, placa={placa}";

            try
            {
                VehiculoBL bl = new VehiculoBL();
                int idVehiculo = bl.InsertarVehiculo(idCliente, marca, modelo, anio, placa, color);

                log.Info($"Vehículo insertado correctamente. IdVehiculo={idVehiculo}");
                RegistrarLogServicio(servicio, parametros, $"OK - IdVehiculo={idVehiculo}");

                return idVehiculo;
            }
            catch (Exception ex)
            {
                log.Error($"Error en {servicio}", ex);
                RegistrarLogServicio(servicio, parametros, $"ERROR - {ex.Message}");
                throw;
            }
        }


        [WebMethod]
        public int InsertarFacturaPrueba(int idCliente, int idVehiculo, int idUsuario, int idSucursal, string canalVenta, decimal subtotal, decimal impuesto, decimal total)
        {
            string servicio = "InsertarFacturaPrueba";
            string parametros = $"idCliente={idCliente}, idVehiculo={idVehiculo}, idUsuario={idUsuario}, idSucursal={idSucursal}, canalVenta={canalVenta}, subtotal={subtotal}, impuesto={impuesto}, total={total}";

            try
            {
                FacturaBL bl = new FacturaBL();
                int idFactura = bl.InsertarFactura(idCliente, idVehiculo, idUsuario, idSucursal, canalVenta, subtotal, impuesto, total);

                log.Info($"Factura insertada correctamente. IdFactura={idFactura}");
                RegistrarLogServicio(servicio, parametros, $"OK - IdFactura={idFactura}");
                RegistrarAuditoria(idUsuario, "FACTURACION", "INSERTAR", $"Se creó la factura {idFactura}");

                return idFactura;
            }
            catch (Exception ex)
            {
                log.Error($"Error en {servicio}", ex);
                RegistrarLogServicio(servicio, parametros, $"ERROR - {ex.Message}");
                throw;
            }
        }

        [WebMethod]
        public void InsertarFacturaDetalleServicioPrueba(int idFactura, int idServicio, int cantidad, decimal precio)
        {
            string servicio = "InsertarFacturaDetalleServicioPrueba";
            string parametros = $"idFactura={idFactura}, idServicio={idServicio}, cantidad={cantidad}, precio={precio}";

            try
            {
                FacturaBL bl = new FacturaBL();
                bl.InsertarFacturaDetalle(idFactura, null, idServicio, cantidad, precio);

                log.Info($"Detalle de servicio insertado correctamente para factura {idFactura}");
                RegistrarLogServicio(servicio, parametros, "OK - Detalle servicio insertado");
            }
            catch (Exception ex)
            {
                log.Error($"Error en {servicio}", ex);
                RegistrarLogServicio(servicio, parametros, $"ERROR - {ex.Message}");
                throw;
            }
        }

        [WebMethod]
        public void RegistrarMovimientoInventario(int idProducto, int idSucursal, string tipoMovimiento, int cantidad, string observacion, int idUsuario)
        {
            InventarioBL bl = new InventarioBL();
            bl.RegistrarMovimientoInventario(idProducto, idSucursal, tipoMovimiento, cantidad, observacion, idUsuario);
        }

        [WebMethod]
        public void InsertarFacturaDetalleProductoPrueba(int idFactura, int idProducto, int cantidad, decimal precio)
        {
            string servicio = "InsertarFacturaDetalleProductoPrueba";
            string parametros = $"idFactura={idFactura}, idProducto={idProducto}, cantidad={cantidad}, precio={precio}";

            try
            {
                FacturaBL bl = new FacturaBL();
                bl.InsertarFacturaDetalle(idFactura, idProducto, null, cantidad, precio);

                log.Info($"Detalle de producto insertado correctamente para factura {idFactura}");
                RegistrarLogServicio(servicio, parametros, "OK - Detalle producto insertado");
            }
            catch (Exception ex)
            {
                log.Error($"Error en {servicio}", ex);
                RegistrarLogServicio(servicio, parametros, $"ERROR - {ex.Message}");
                throw;
            }
        }


    }
}