using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.Controllers
{
    public class MVC11SessionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "Admin" && sifre == "1236") // eğer ekrandan gönderilen değerler admin ve 1236 ise
            {
                //Session["deger"] = "Admin"; // Bir session oluştur adı deger olsun ve üzerinde Admin verisini taşısın.
                HttpContext.Session.SetString("deger", "Admin");
                TempData["mesaj"] = "<div class='alert alert-success'>Giriş Başarılı!</div>";
            }
            else
            {
                TempData["mesaj"] = "<div class='alert alert-danger'>Giriş Başarısız!</div>";
            }
            return View("Index");
        }
        public IActionResult SessionOku()
        {
            if (HttpContext.Session.GetString("deger") != null)
            {
                TempData["mesaj"] = $"<div class='alert alert-success'>Hoşgeldin {HttpContext.Session.GetString("deger")}</div>";
            }
            else
            {
                TempData["mesaj"] = "<div class='alert alert-danger'>Giriş Yapılmamış!</div>";
            }
            return View();
        }
    }
}
