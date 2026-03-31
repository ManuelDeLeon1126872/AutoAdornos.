using System.Collections.Generic;
using System.Linq;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Clientes
{
    public class ClienteBL
    {
        public List<sp_ListarClientes_Result> ListarClientes()
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ListarClientes().ToList();
            }
        }

        public sp_BuscarClientePorId_Result BuscarClientePorId(int idCliente)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_BuscarClientePorId(idCliente).FirstOrDefault();
            }
        }

        public sp_BuscarClientePorCedulaRNC_Result BuscarClientePorCedulaRNC(string cedulaRnc)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_BuscarClientePorCedulaRNC(cedulaRnc).FirstOrDefault();
            }
        }

        public int InsertarCliente(string nombre, string cedulaRnc, string telefono, string direccion, string email, bool esAnonimo)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                var resultado = db.sp_InsertarCliente(nombre, cedulaRnc, telefono, direccion, email, esAnonimo).FirstOrDefault();
                return resultado.HasValue ? (int)resultado.Value : 0;
            }
        }
    }
}