using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.Controllers
{
    public class MVC10CookieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CookieOlustur(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "admin" && sifre == "123456")
            {
                CookieOptions cookieAyarlari = new()
                {
                    Expires = DateTime.Now.AddMinutes(1)
                };
                Response.Cookies.Append("kullaniciAdi", kullaniciAdi, cookieAyarlari);
                Response.Cookies.Append("sifre", sifre, cookieAyarlari);
                Response.Cookies.Append("userguid", Guid.NewGuid().ToString());
                TempData["mesaj"] = "<div class='alert alert-success'>Cookie Oluşturuldu!</div>";
                return RedirectToAction("CookieOku");
            }
            else TempData["mesaj"] = "<div class='alert alert-danger'>Cookie Oluşturulamadı!</div>";
            return RedirectToAction("Index");
        }
        public ActionResult CookieOku()
        {
            if (HttpContext.Request.Cookies["kullaniciAdi"] is null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult CookieSil()
        {
            if (HttpContext.Request.Cookies["kullaniciAdi"] != null)
            {
                Response.Cookies.Delete("kullaniciAdi");
                Response.Cookies.Delete("sifre");
                Response.Cookies.Delete("userguid");
            }
            TempData["mesaj"] = "<div class='alert alert-danger'>Cookie Silindi!</div>";
            return RedirectToAction("Index");
        }
    }
}
