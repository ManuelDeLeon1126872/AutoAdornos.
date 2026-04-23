using System;
using System.ServiceModel;
using System.Xml.Serialization;

namespace AutoAdornos.Web.UI.Services
{
    [ServiceContract(Namespace = "http://autoadornos.com/")]
    [XmlSerializerFormat]
    public interface IIntegracionServiceSoap
    {
        [OperationContract(Action = "http://autoadornos.com/ListarProductos", ReplyAction = "*")]
        Cache_tblProducto[] ListarProductos();

        [OperationContract(Action = "http://autoadornos.com/ValidarUsuario", ReplyAction = "*")]
        bool ValidarUsuario(string usuario, string clave);

        [OperationContract(Action = "http://autoadornos.com/RegistrarVenta", ReplyAction = "*")]
        string RegistrarVenta(int idCliente, int idVehiculo, int idUsuario, int idSucursal, string canalVenta, decimal total, ItemVenta[] detalles);

        [OperationContract(Action = "http://autoadornos.com/SincronizarVentasOffline", ReplyAction = "*")]
        string SincronizarVentasOffline();

        // EL ARREGLO ESTÁ AQUÍ: Le pusimos el mismo formato que tienen los demás
        [OperationContract(Action = "http://autoadornos.com/RegistrarUsuarioWeb", ReplyAction = "*")]
        bool RegistrarUsuarioWeb(string nombreUsuario, string clave, string nombreCompleto);
    }

    [Serializable]
    [XmlType(Namespace = "http://autoadornos.com/")]
    public class Cache_tblProducto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public int? Existencia { get; set; }
    }

    [Serializable]
    [XmlType(Namespace = "http://autoadornos.com/")]
    public class ItemVenta
    {
        public int? IdProducto { get; set; }
        public int? IdServicio { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}