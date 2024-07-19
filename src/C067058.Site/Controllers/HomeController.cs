using Microsoft.AspNetCore.Mvc;

namespace C067058.Site.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToAction("", "simulador-de-emprestimos-imobiliarios");
        }
    }
}
