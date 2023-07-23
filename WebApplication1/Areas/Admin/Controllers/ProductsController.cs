using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class ProductsController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public ProductsController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            // return View(_databaseContext.Products.Include("Category").ToList());
            //return View(_databaseContext.Products.Include(c => c.Category).ToList()); // . net core da ürünlerle birlikte kategorileri de göstermek için include metoduyla dahil etmemiz gerekiyor!
            return View(await _databaseContext.Products.Include("Category").ToListAsync());
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    string directory = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName; // dosyanın sunucuda yükleneceği konumu ayarladık
                    using var stream = new FileStream(directory, FileMode.Create); // dosyanın seçildiği cihazdan sunucuya doğru bir veri akışı oluşturuyoruz FileStream nesnesiyle
                    Image.CopyTo(stream); // dosyayı yukardaki ayarlar ile sunucuya kopyalıyoruz
                    collection.Image = Image.FileName; // yüklenen dosyanın adını ürün resim adına yazdırıyoruz
                }
                _databaseContext.Products.Add(collection);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(_databaseContext.Categories.ToList(), "Id", "Name");
            var model = _databaseContext.Products.Find(id);
            return View(model);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    string directory = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                    using var stream = new FileStream(directory, FileMode.Create);
                    Image.CopyTo(stream);
                    collection.Image = Image.FileName;
                }
                _databaseContext.Products.Update(collection);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _databaseContext.Products.Find(id);
            return View(model);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                _databaseContext.Products.Remove(collection);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
