using AutoAdornos.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;

namespace AutoAdornos.Web.UI.Services
{
    public class IntegracionSoapClient
    {
        private readonly string _serviceUrl;

        public IntegracionSoapClient()
        {
            _serviceUrl = ConfigurationManager.AppSettings["IntegracionServiceUrl"];
            if (string.IsNullOrWhiteSpace(_serviceUrl))
            {
                throw new ConfigurationErrorsException("Falta la clave IntegracionServiceUrl en Web.config");
            }
        }

        private IIntegracionServiceSoap BuildClient(out ChannelFactory<IIntegracionServiceSoap> factory)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None)
            {
                MaxReceivedMessageSize = 1024 * 1024 * 5,
                ReaderQuotas = { MaxArrayLength = 1024 * 1024, MaxStringContentLength = 1024 * 1024 }
            };

            factory = new ChannelFactory<IIntegracionServiceSoap>(binding, new EndpointAddress(_serviceUrl));
            return factory.CreateChannel();
        }

        public List<ProductoViewModel> ListarProductos()
        {
            ChannelFactory<IIntegracionServiceSoap> factory = null;
            try
            {
                var client = BuildClient(out factory);
                var response = client.ListarProductos() ?? new Cache_tblProducto[0];

                return response
                    .Select(x => new ProductoViewModel
                    {
                        IdProducto = x.IdProducto,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        Precio = x.Precio ?? 0m,
                        Existencia = x.Existencia ?? 0
                    })
                    .OrderBy(x => x.Descripcion)
                    .ToList();
            }
            finally
            {
                CloseFactory(factory);
            }
        }

        public bool ValidarUsuario(string usuario, string clave)
        {
            ChannelFactory<IIntegracionServiceSoap> factory = null;
            try
            {
                var client = BuildClient(out factory);
                return client.ValidarUsuario(usuario, clave);
            }
            finally
            {
                CloseFactory(factory);
            }
        }

        public string RegistrarVenta(UserSessionModel user, IEnumerable<CartItemViewModel> items)
        {
            if (user == null)
            {
                throw new InvalidOperationException("No hay una sesión de usuario activa.");
            }

            var detalles = items.Select(x => new ItemVenta
            {
                IdProducto = x.IdProducto,
                IdServicio = null,
                Cantidad = x.Cantidad,
                Precio = x.Precio
            }).ToArray();

            var total = items.Sum(x => x.Subtotal);

            ChannelFactory<IIntegracionServiceSoap> factory = null;
            try
            {
                var client = BuildClient(out factory);
                return client.RegistrarVenta(
                    user.IdClienteDefault,
                    user.IdVehiculoDefault,
                    user.IdUsuario,
                    user.IdSucursal,
                    "WEB",
                    total,
                    detalles);
            }
            finally
            {
                CloseFactory(factory);
            }
        }

        private static void CloseFactory(ChannelFactory<IIntegracionServiceSoap> factory)
        {
            if (factory == null)
            {
                return;
            }

            try
            {
                if (factory.State != CommunicationState.Faulted)
                {
                    factory.Close();
                }
                else
                {
                    factory.Abort();
                }
            }
            catch
            {
                factory.Abort();
            }
        }
    }
}
