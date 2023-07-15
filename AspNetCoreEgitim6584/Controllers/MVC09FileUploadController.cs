using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.Controllers
{
    public class MVC09FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile? dosya) // .net core da dosya yükleme için ön yüzdeki file ın name değerini IFormFile ile yakalıyoruz
        {
            if (dosya is not null)
            {
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + dosya.FileName; // dosyanın sunucuda yükleneceği konumu ayarladık
                using var stream = new FileStream(directory, FileMode.Create); // dosyanın seçildiği cihazdan sunucuya doğru bir veri akışı oluşturuyoruz FileStream nesnesiyle
                dosya.CopyTo(stream); // dosyayı yukardaki ayarlar ile sunucuya kopyalıyoruz
                TempData["Resim"] = dosya.FileName;
            }
            return View();
        }
    }
}
