using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.Controllers
{
    public class MVC01RazorSyntaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
