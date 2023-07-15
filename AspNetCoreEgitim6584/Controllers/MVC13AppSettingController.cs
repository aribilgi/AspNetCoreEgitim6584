using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.Controllers
{
    public class MVC13AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;

        public MVC13AppSettingController(IConfiguration configuration) // Bu yönteme Dependency Injection deniliyor. Kısaca DI diye de bahsedilir.
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            TempData["Email"] = _configuration["Email"];
            TempData["MailSunucu"] = _configuration["MailSunucu"];// _configuration daki ana satır verisi çekme
            TempData["KullaniciAdi"] = _configuration["MailKullanici:UserName"]; // _configuration daki iç içe veri çekme yöntemi
            TempData["Sifre"] = _configuration.GetSection("MailKullanici:Password").Value; // _configuration dan veri çekmenin diğer yöntemi
            return View();
        }
    }
}
