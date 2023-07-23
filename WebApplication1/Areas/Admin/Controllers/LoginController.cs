using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;

        public LoginController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string email, string password)
        {
            try
            {
                var kullanici = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
                if (kullanici != null) // eğer girilen bilgilerle eşleşen kullanıcı varsa
                {
                    var haklar = new List<Claim>() // kullanıcı hakları tanımladık
                    {
                        new Claim(ClaimTypes.Email, email) // claim = hak(kullanıcıya tanımlalan haklar)
                    };
                    var kullaniciKimligi = new ClaimsIdentity(haklar, "Login"); // kullanıcı için bir kimlik oluşturduk
                    ClaimsPrincipal claimsPrincipal = new(kullaniciKimligi);
                    await HttpContext.SignInAsync(claimsPrincipal); // yukardaki yetkilerle sisteme giriş yaptık
                    return Redirect("/Admin");
                }
                else TempData["Message"] = "<div class='alert alert-danger'>Giriş Başarısız!</div>";
            }
            catch (Exception)
            {
                TempData["Message"] = "<div class='alert alert-danger'>Hata Oluştu!</div>";
            }
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(); // oturumu kapat
            return Redirect("/Admin/Login"); // yeniden logine yönlendir
        }
    }
}
