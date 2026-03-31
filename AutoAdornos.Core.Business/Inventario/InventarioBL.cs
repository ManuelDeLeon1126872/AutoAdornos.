using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Inventario
{
    public class InventarioBL
    {
        public void RegistrarMovimientoInventario(int idProducto, int idSucursal, string tipoMovimiento, int cantidad, string observacion, int idUsuario)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                db.sp_RegistrarMovimientoInventario(idProducto, idSucursal, tipoMovimiento, cantidad, observacion, idUsuario);
            }
        }
    }
}