using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) // eğer adres çubuğundan id yollanmamışsa
            {
                return BadRequest(); // geriye geçersiz - bozuk istek hatası dön
            }
            var kategori = await _context.Categories.Include(p => p.Products).FirstOrDefaultAsync(p => p.Id == id);
            if (kategori is null) // veritabanında eğer gönderilen id ile eşleşen kayıt yoksa
            {
                return NotFound(); // geriye kayıt bulunamadı hatası dön
            }
            return View(kategori); // her şey yolundaysa ve kategori bulunduysa ekrana bu kategoriyi yolla 
        }
    }
}
