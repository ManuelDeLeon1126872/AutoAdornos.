using System;
using System.Linq;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Facturacion
{
    public class FacturaBL
    {
        public int InsertarFactura(int idCliente, int? idVehiculo, int idUsuario, int idSucursal, string canalVenta, decimal subtotal, decimal impuesto, decimal total)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                int? vehiculoFinal = idVehiculo;

                if (!vehiculoFinal.HasValue)
                {
                    var vehiculoGenerico = db.tblVehiculoes
                                             .FirstOrDefault(v => v.Marca == "GENERICA"
                                                               && v.Modelo == "VENTA RAPIDA"
                                                               && v.Estado == true);

                    if (vehiculoGenerico == null)
                        throw new Exception("No existe un vehículo genérico configurado.");

                    vehiculoFinal = vehiculoGenerico.IdVehiculo;
                }

                var resultado = db.sp_InsertarFactura(idCliente, vehiculoFinal, idUsuario, idSucursal, canalVenta, subtotal, impuesto, total).FirstOrDefault();

                return resultado.HasValue ? (int)resultado.Value : 0;
            }
        }

        public void InsertarFacturaDetalle(int idFactura, int? idProducto, int? idServicio, int cantidad, decimal precio)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                db.sp_InsertarFacturaDetalle(idFactura, idProducto, idServicio, cantidad, precio);
            }
        }
    }
}