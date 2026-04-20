using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AutoAdornos.Web.UI.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

        [Required(ErrorMessage = "La cédula o RNC es obligatoria")]
        [Display(Name = "Cédula / RNC")]
        public string CedulaRnc { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [Display(Name = "Nombre del cliente")]
        public string NombreCliente { get; set; }

        [Display(Name = "Observación")]
        public string Observacion { get; set; }

        public decimal Total => Items?.Sum(x => x.Subtotal) ?? 0m;
    }
}
