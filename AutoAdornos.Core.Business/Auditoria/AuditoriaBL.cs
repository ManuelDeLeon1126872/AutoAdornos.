using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Auditoria
{
    public class AuditoriaBL
    {
        public void InsertarAuditoria(int idUsuario, string modulo, string accion, string descripcion)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                db.sp_InsertarAuditoria(idUsuario, modulo, accion, descripcion);
            }
        }

        public void InsertarLogServicio(string servicio, string parametros, string respuesta)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                db.sp_InsertarLogServicio(servicio, parametros, respuesta);
            }
        }
    }
}