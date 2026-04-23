using AutoAdornos.Web.UI.Helpers;
using AutoAdornos.Web.UI.Models;
using AutoAdornos.Web.UI.Services;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace AutoAdornos.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (CartSessionManager.IsAuthenticated(Session))
            {
                return RedirectToAction("Index", "Store");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var client = new IntegracionSoapClient();
                var isValid = client.ValidarUsuario(model.Usuario, model.Clave);

                if (!isValid)
                {
                    ModelState.AddModelError(string.Empty, "Usuario o clave incorrectos.");
                    return View(model);
                }

                var user = new UserSessionModel
                {
                    Usuario = model.Usuario,
                    IdUsuario = int.Parse(ConfigurationManager.AppSettings["DefaultWebUserId"] ?? "1"),
                    IdSucursal = int.Parse(ConfigurationManager.AppSettings["DefaultSucursalId"] ?? "1"),
                    IdClienteDefault = int.Parse(ConfigurationManager.AppSettings["DefaultClienteId"] ?? "2"),
                    IdVehiculoDefault = int.Parse(ConfigurationManager.AppSettings["DefaultVehiculoId"] ?? "1"),
                    EstaAutenticado = true
                };

                CartSessionManager.SaveUser(Session, user);
                return RedirectToAction("Index", "Store");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No fue posible conectar con la capa de Integración: " + ex.Message);
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            CartSessionManager.Logout(Session);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // 1. Usamos el cliente manual (Igual que en el Login)
                var client = new IntegracionSoapClient();

                // 2. Ejecutamos el registro a través del puente
                bool exito = client.RegistrarUsuarioWeb(model.Usuario, model.Clave, model.NombreCompleto);

                if (exito)
                {
                    // 3. Si tuvo éxito, lo logueamos usando la misma lógica de sesión que el Login
                    var user = new UserSessionModel
                    {
                        Usuario = model.Usuario,
                        IdUsuario = int.Parse(ConfigurationManager.AppSettings["DefaultWebUserId"] ?? "1"),
                        IdSucursal = int.Parse(ConfigurationManager.AppSettings["DefaultSucursalId"] ?? "1"),
                        IdClienteDefault = int.Parse(ConfigurationManager.AppSettings["DefaultClienteId"] ?? "2"),
                        IdVehiculoDefault = int.Parse(ConfigurationManager.AppSettings["DefaultVehiculoId"] ?? "1"),
                        EstaAutenticado = true
                    };

                    CartSessionManager.SaveUser(Session, user);

                    // 4. Lo mandamos directo a la tienda para que empiece a comprar
                    return RedirectToAction("Index", "Store");
                }
                else
                {
                    ViewBag.Error = "Error al registrar. Es posible que el usuario ya exista en el sistema.";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error de comunicación con el servidor central: " + ex.Message;
                return View(model);
            }
        }
    }
}