using System.Collections.Generic;
using System.Linq;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Catalogos
{
    public class ServicioBL
    {
        public List<sp_ListarServicios_Result> ListarServicios()
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ListarServicios().ToList();
            }
        }
    }
}