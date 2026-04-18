using AutoAdornos.Web.UI.Helpers;
using System.Web.Mvc;

namespace AutoAdornos.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!CartSessionManager.IsAuthenticated(Session))
            {
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Index", "Store");
        }
    }
}
