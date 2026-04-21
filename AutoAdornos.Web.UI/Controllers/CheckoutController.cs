using AutoAdornos.Web.UI.Helpers;
using AutoAdornos.Web.UI.Models;
using AutoAdornos.Web.UI.Services;
using System;
using System.Web.Mvc;

namespace AutoAdornos.Web.UI.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IntegracionSoapClient _client = new IntegracionSoapClient();

        [HttpGet]
        public ActionResult Index()
        {
            if (!CartSessionManager.IsAuthenticated(Session))
            {
                return RedirectToAction("Login", "Account");
            }

            var cart = CartSessionManager.GetCart(Session);
            if (cart.Count == 0)
            {
                TempData["Error"] = "El carrito está vacío.";
                return RedirectToAction("Index", "Store");
            }

            return View(new CheckoutViewModel { Items = cart });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CheckoutViewModel model)
        {
            if (!CartSessionManager.IsAuthenticated(Session))
            {
                return RedirectToAction("Login", "Account");
            }

            model.Items = CartSessionManager.GetCart(Session);
            if (model.Items.Count == 0)
            {
                TempData["Error"] = "El carrito está vacío.";
                return RedirectToAction("Index", "Store");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = CartSessionManager.GetUser(Session);
                var respuesta = _client.RegistrarVenta(user, model.Items);

                ViewBag.Respuesta = respuesta;
                ViewBag.Total = model.Total;

                var modeloParaFactura = new CheckoutViewModel { Items = new System.Collections.Generic.List<CartItemViewModel>(model.Items) };

                CartSessionManager.ClearCart(Session);

                return View("Resultado", modeloParaFactura);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No fue posible registrar la venta: " + ex.Message);
                return View(model);
            }
        }
    }
}
