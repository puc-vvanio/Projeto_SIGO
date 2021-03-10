using Microsoft.AspNetCore.Mvc;

namespace Sigo.Normas.API.Controllers
{
    public class Normas : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
