using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents
{
    public class Kategoriler : ViewComponent
    {
        private readonly DatabaseContext _context;

        public Kategoriler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Categories.ToListAsync());
        }
    }
}
