using Microsoft.AspNetCore.Mvc;

namespace Sigo.Normas.API.Controllers
{
    public class Consultorias : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
