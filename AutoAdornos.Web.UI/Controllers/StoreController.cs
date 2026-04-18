using AutoAdornos.Web.UI.Helpers;
using AutoAdornos.Web.UI.Models;
using AutoAdornos.Web.UI.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AutoAdornos.Web.UI.Controllers
{
    public class StoreController : Controller
    {
        private readonly IntegracionSoapClient _client = new IntegracionSoapClient();

        public ActionResult Index(string q = null)
        {
            if (!CartSessionManager.IsAuthenticated(Session))
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                var productos = _client.ListarProductos();

                if (!string.IsNullOrWhiteSpace(q))
                {
                    var term = q.Trim().ToLowerInvariant();
                    productos = productos
                        .Where(x => (x.Descripcion ?? string.Empty).ToLowerInvariant().Contains(term)
                                 || (x.Codigo ?? string.Empty).ToLowerInvariant().Contains(term)
                                 || x.IdProducto.ToString() == term)
                        .ToList();
                }

                ViewBag.Search = q;
                return View(productos);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "No fue posible cargar el catálogo: " + ex.Message;
                return View(Enumerable.Empty<ProductoViewModel>());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int idProducto, string codigo, string descripcion, decimal precio, int cantidad = 1)
        {
            if (!CartSessionManager.IsAuthenticated(Session))
            {
                return RedirectToAction("Login", "Account");
            }

            if (cantidad <= 0)
            {
                cantidad = 1;
            }

            CartSessionManager.AddItem(Session, new CartItemViewModel
            {
                IdProducto = idProducto,
                Codigo = codigo,
                Descripcion = descripcion,
                Precio = precio,
                Cantidad = cantidad
            });

            TempData["Success"] = "Producto agregado al carrito.";
            return RedirectToAction("Index");
        }

        public ActionResult Cart()
        {
            if (!CartSessionManager.IsAuthenticated(Session))
            {
                return RedirectToAction("Login", "Account");
            }

            return View(CartSessionManager.GetCart(Session));
        }

        public ActionResult Remove(int id)
        {
            CartSessionManager.RemoveItem(Session, id);
            TempData["Success"] = "Producto removido del carrito.";
            return RedirectToAction("Cart");
        }
    }
}
