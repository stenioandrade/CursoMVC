using System.Web.Mvc;

namespace EP.CursoMvc.UI.Site.Controllers
{
    [RoutePrefix("")]
    public class VitrineController : Controller
    {
        [Route("{idProduto:int}/{vitrine:alpha}/{palavrasChave:maxlength(200)}/{afiliado:maxlength(15)}")]
        public ActionResult Index(int idProduto, string vitrine, string palavrasChave, string afiliado)
        {
            return View();
        }
    }
}