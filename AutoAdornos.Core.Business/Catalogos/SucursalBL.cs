using System.Collections.Generic;
using System.Linq;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Catalogos
{
    public class SucursalBL
    {
        public List<sp_ListarSucursales_Result> ListarSucursales()
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ListarSucursales().ToList();
            }
        }
    }
}