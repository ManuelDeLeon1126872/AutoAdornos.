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

        // 1. REEMPLAZAMOS EL INSERTAR PARA QUE RECIBA EL PERFIL (Le ponemos idPerfil = 1 por defecto por si alguien más lo usa)
        public int InsertarUsuario(string nombreUsuario, string clave, string nombreCompleto, int idSucursal, bool estado, int idPerfil = 1)
        {
            using (var db = new AutoAdornos.Core.Data.DBAutoAdornosCoreEntities())
            {
                db.Database.ExecuteSqlCommand(
                    "INSERT INTO tblUsuario (NombreUsuario, Clave, NombreCompleto, IdSucursal, Estado, IdPerfil) VALUES ({0}, {1}, {2}, {3}, {4}, {5})",
                    nombreUsuario, clave, nombreCompleto, idSucursal, estado, idPerfil
                );

                // LA MAGIA: Le decimos a SQL que haga CAST a INT antes de devolverlo
                return db.Database.SqlQuery<int>("SELECT CAST(IDENT_CURRENT('tblUsuario') AS INT)").FirstOrDefault();
            }
        }

        // 2. AGREGAMOS EL MÉTODO DE ACTUALIZAR
        public void ActualizarUsuario(int idUsuario, string nombreUsuario, string clave, string nombreCompleto, int idSucursal, bool estado, int idPerfil)
        {
            using (var db = new AutoAdornos.Core.Data.DBAutoAdornosCoreEntities())
            {
                if (string.IsNullOrWhiteSpace(clave))
                {
                    // Si el administrador dejó la clave en blanco, actualizamos todo MENOS la clave
                    db.Database.ExecuteSqlCommand(
                        "UPDATE tblUsuario SET NombreUsuario = {0}, NombreCompleto = {1}, IdSucursal = {2}, Estado = {3}, IdPerfil = {4} WHERE IdUsuario = {5}",
                        nombreUsuario, nombreCompleto, idSucursal, estado, idPerfil, idUsuario
                    );
                }
                else
                {
                    // Si escribió una clave, actualizamos todo completo
                    db.Database.ExecuteSqlCommand(
                        "UPDATE tblUsuario SET NombreUsuario = {0}, Clave = {1}, NombreCompleto = {2}, IdSucursal = {3}, Estado = {4}, IdPerfil = {5} WHERE IdUsuario = {6}",
                        nombreUsuario, clave, nombreCompleto, idSucursal, estado, idPerfil, idUsuario
                    );
                }
            }
        }

        // 3. AGREGAMOS EL MÉTODO DE ELIMINAR
        public void EliminarUsuario(int idUsuario)
        {
            using (var db = new AutoAdornos.Core.Data.DBAutoAdornosCoreEntities())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM tblUsuario WHERE IdUsuario = {0}", idUsuario);
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