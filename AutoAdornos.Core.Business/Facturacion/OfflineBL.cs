using System;
using AutoAdornos.Core.Data;

namespace AutoAdornos.Core.Business.Facturacion
{
    public class OfflineBL
    {
        public bool RecibirFacturaOffline(string idLocal, string cliente, decimal total, string canal)
        {
            using (var db = new DBAutoAdornosCoreEntities())
            {
                try
                {
                    if (canal != "WEB" && canal != "CAJA")
                        return false;

                    var facturaOffline = new tblFacturaOfflineRecibida
                    {
                        IdLocal = idLocal,
                        Cliente = cliente,
                        Total = total,
                        Canal = canal,
                        FechaRecepcion = DateTime.Now,
                        Estado = "RECIBIDA"
                    };

                    db.tblFacturaOfflineRecibidas.Add(facturaOffline);
                    db.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}