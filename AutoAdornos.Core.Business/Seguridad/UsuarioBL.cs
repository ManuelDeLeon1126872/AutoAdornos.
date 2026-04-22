using System.Collections.Generic;
using System.Linq;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Seguridad
{
    public class UsuarioBL
    {
        public sp_ValidarUsuario_Result1 ValidarUsuario(string nombreUsuario, string clave)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ValidarUsuario(nombreUsuario, clave).FirstOrDefault();
            }
        }

        public int InsertarUsuario(string nombreUsuario, string clave, string nombreCompleto, int idSucursal, bool estado)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                var resultado = db.sp_InsertarUsuario(nombreUsuario, clave, nombreCompleto, idSucursal, estado).FirstOrDefault();
                return resultado.HasValue ? (int)resultado.Value : 0;
            }
        }

        public List<sp_ListarUsuarios_Result> ListarUsuarios()
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ListarUsuarios().ToList();
            }
        }
    }
}