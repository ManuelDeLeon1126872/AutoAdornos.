using System.ComponentModel.DataAnnotations;

namespace AutoAdornos.Web.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Clave { get; set; }
    }
}
