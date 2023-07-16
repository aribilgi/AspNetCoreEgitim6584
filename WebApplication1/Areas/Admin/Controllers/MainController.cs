using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")] // admin panelindeki controller lara bunu eklemezsek sayfa çalışmıyor!
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
