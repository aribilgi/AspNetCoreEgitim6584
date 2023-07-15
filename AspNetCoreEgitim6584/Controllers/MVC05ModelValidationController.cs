using AspNetCoreEgitim6584.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        static List<Uye> uyeListesi = new List<Uye>()
        {
            new Uye(){ Ad = "Alp", Soyad = "Arslan", Email = "alp@arslan.com" },
            new Uye(){ Ad = "Murat", Soyad = "Yılmaz", Email = "mur@arslan.com" },
            new Uye(){ Ad = "Deniz", Soyad = "Gökçe", Email = "deniz@google.com" }
        };
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult UyeListesi()
        {
            return View(uyeListesi);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Uye uye)
        {
            return View(uye);
        }
    }
}
