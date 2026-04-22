using System.Collections.Generic;
using System.Linq;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Catalogos
{
    public class ProductoBL
    {
        public int InsertarProducto(string codigo, string descripcion, decimal precio, int existencia, bool estado)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                var resultado = db.sp_InsertarProducto(codigo, descripcion, precio, existencia, estado).FirstOrDefault();
                return resultado.HasValue ? (int)resultado.Value : 0;
            }
        }

        public List<sp_ListarProductosAdmin_Result> ListarProductosAdmin()
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ListarProductosAdmin().ToList();
            }
        }

        public List<sp_ListarProductos_Result> ListarProductos()
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ListarProductos().ToList();
            }
        }

        public sp_BuscarProductoPorId_Result BuscarProductoPorId(int idProducto)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_BuscarProductoPorId(idProducto).FirstOrDefault();
            }
        }

        public void ActualizarProducto(int idProducto, string codigo, string descripcion, decimal precio, int existencia, bool estado)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                db.Database.ExecuteSqlCommand(
                    "UPDATE tblProducto SET Codigo = {0}, Descripcion = {1}, Precio = {2}, Existencia = {3}, Estado = {4} WHERE IdProducto = {5}",
                    codigo, descripcion, precio, existencia, estado, idProducto);
            }
        }
    }
}