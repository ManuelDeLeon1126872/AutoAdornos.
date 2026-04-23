using System.Collections.Generic;
using System.Linq;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Catalogos
{
    public class SucursalBL
    {
        public int InsertarSucursal(string nombre, string direccion, string telefono, bool estado)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                var resultado = db.sp_InsertarSucursal(nombre, direccion, telefono, estado).FirstOrDefault();
                return resultado.HasValue ? (int)resultado.Value : 0;
            }
        }

        public List<sp_ListarSucursalesAdmin_Result> ListarSucursalesAdmin()
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ListarSucursalesAdmin().ToList();
            }
        }

        public List<sp_ListarSucursales_Result> ListarSucursales()
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ListarSucursales().ToList();
            }
        }

        public void ActualizarSucursal(int idSucursal, string nombre, string direccion, string telefono, bool estado)
        {
            using (var db = new AutoAdornos.Core.Data.DBAutoAdornosCoreEntities())
            {
                // Usamos SQL directo a prueba de balas
                db.Database.ExecuteSqlCommand(
                    "UPDATE tblSucursal SET Nombre = {0}, Direccion = {1}, Telefono = {2}, Estado = {3} WHERE IdSucursal = {4}",
                    nombre, direccion, telefono, estado, idSucursal
                );
            }
        }

        public void EliminarSucursal(int idSucursal)
        {
            using (var db = new AutoAdornos.Core.Data.DBAutoAdornosCoreEntities())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM tblSucursal WHERE IdSucursal = {0}", idSucursal);
            }
        }
    }
}