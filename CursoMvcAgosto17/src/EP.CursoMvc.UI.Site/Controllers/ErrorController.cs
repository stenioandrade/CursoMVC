using System.Web.Mvc;

namespace EP.CursoMvc.UI.Site.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(int? code)
        {
            return View("Error");
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }

        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}