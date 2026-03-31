using System.Collections.Generic;
using System.Linq;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Catalogos
{
    public class ProductoBL
    {
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
    }
}