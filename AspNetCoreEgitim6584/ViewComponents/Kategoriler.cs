using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEgitim6584.ViewComponents
{
    public class Kategoriler : ViewComponent // Kategoriler sınıfını .net içerisindeki ViewComponent sınıfından kalıtım alarak ViewComponent e dönüştürüyoruz
    {
        public IViewComponentResult Invoke() // bu metot içerisinde veri tabanından kategorileri çekip ViewComponent ekranına gönderebiliriz
        {
            return View();
        }
    }
}
