using AspNetCoreEgitim6584.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.Controllers
{
    public class MVC14FiltersController : Controller
    {
        [UserControl]
        public IActionResult Index()
        {
            return View();
        }
    }
}
