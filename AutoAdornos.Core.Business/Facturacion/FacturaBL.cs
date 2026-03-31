using AutoAdornos.Core.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace AutoAdornos.Core.Business.Facturacion
{
    public class FacturaBL
    {
        public int InsertarFactura(int idCliente, int? idVehiculo, int idUsuario, int idSucursal, string canalVenta, decimal subtotal, decimal impuesto, decimal total)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                var resultado = db.sp_InsertarFactura(idCliente, idVehiculo, idUsuario, idSucursal, canalVenta, subtotal, impuesto, total).FirstOrDefault();
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

        public ObjectResult<sp_ConsultarFacturaPorId_Result> ConsultarFacturaPorId(int idFactura)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ConsultarFacturaPorId(idFactura);
            }
        }
    }
}