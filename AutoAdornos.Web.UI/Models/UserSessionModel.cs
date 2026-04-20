namespace AutoAdornos.Web.UI.Models
{
    public class UserSessionModel
    {
        public string Usuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdSucursal { get; set; }
        public int IdClienteDefault { get; set; }
        public int IdVehiculoDefault { get; set; }
        public bool EstaAutenticado { get; set; }
    }
}
