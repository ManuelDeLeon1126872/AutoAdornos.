using System.Collections.Generic;
using System.Linq;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Vehiculos
{
    public class VehiculoBL
    {
        public List<sp_ListarVehiculosPorCliente_Result> ListarVehiculosPorCliente(int idCliente)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                return db.sp_ListarVehiculosPorCliente(idCliente).ToList();
            }
        }

        public int InsertarVehiculo(int idCliente, string marca, string modelo, int? anio, string placa, string color)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                var resultado = db.sp_InsertarVehiculo(idCliente, marca, modelo, anio, placa, color).FirstOrDefault();
                return resultado.HasValue ? (int)resultado.Value : 0;
            }
        }
    }
}