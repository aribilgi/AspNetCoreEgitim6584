using AspNetCoreEgitim6584.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.Controllers
{
    public class MVC04ModelBindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult KullaniciBilgi()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "mur@yimaz.co",
                Id = 25
            };
            // yukardaki kullanıcıyı aşağıdaki view içerisine yazmazsak sayfada hata alırız
            return View(kullanici); // kullanici nesnesini parantez içerisinde sayfaya model olarak gönderiyoruz
        }
        [HttpPost]
        public ActionResult KullaniciBilgi(Kullanici kullanici) // MVC de view sayfasındaki model class ını buradaki gibi parantez içerisinde yakalayıp metot içerisinde kullanabiliriz(veritabanına ekleme vb işlemler için)
        {
            // burada istersek kullanici nesnesini veritabanına ekleyip uygulamayı da farklı bir ekrana yollayabiliriz
            return View(kullanici); // ekrandan gelen model nesnesini geri ekrana yolladık
        }
        public ActionResult AdresBilgi()
        {
            var model = new Adres
            {
                Sehir = "İstanbul",
                Ilce = "Pendik",
                AcikAdres = "Batı mah. doğu sk. vadi ap."
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult AdresBilgi(Adres adres)
        {
            // burada adresi db ye kaydedebiliriz
            return View(adres);
        }
        public ActionResult KullaniciSayfasi()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "mur@yimaz.co",
                Id = 25
            };
            var adres = new Adres
            {
                Sehir = "İstanbul",
                Ilce = "Pendik",
                AcikAdres = "Batı mah. doğu sk. vadi ap."
            };
            var model = new KullaniciSayfasiViewModel()
            {
                Kullanici = kullanici,
                Adres = adres
            };
            return View(model);
        }
    }
}
