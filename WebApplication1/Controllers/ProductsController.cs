using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _context.Products.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Search(string kelime)
        {
            var model = await _context.Products.Where(x => x.Name.Contains(kelime) || x.Description.Contains(kelime)).ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var urun = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            var product = await _context.Products.Where(p => p.Id == id).Include(c => c.Category).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
