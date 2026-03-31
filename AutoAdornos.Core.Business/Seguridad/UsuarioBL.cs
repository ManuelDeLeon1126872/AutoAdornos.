using System.Linq;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Seguridad
{
    public class UsuarioBL
    {
        public sp_ValidarUsuario_Result ValidarUsuario(string nombreUsuario, string clave)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ValidarUsuario(nombreUsuario, clave).FirstOrDefault();
            }
        }
    }
}