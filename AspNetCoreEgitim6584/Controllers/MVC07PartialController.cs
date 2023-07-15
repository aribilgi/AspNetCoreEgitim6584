using AspNetCoreEgitim6584.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.Controllers
{
    public class MVC07PartialController : Controller
    {
        public IActionResult Index()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "mur@yimaz.co",
                Id = 25
            };
            return View(kullanici);
        }
    }
}
