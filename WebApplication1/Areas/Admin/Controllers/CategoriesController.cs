using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        DatabaseContext databaseContext = new DatabaseContext();
        // GET: CategoriesController
        public ActionResult Index()
        {
            var model = databaseContext.Categories.ToList();
            return View(model);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category collection)
        {
            try
            {
                databaseContext.Categories.Add(collection);
                databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            //var model = databaseContext.Categories.Find(id);
            //var model = await databaseContext.Categories.FindAsync(id); // bir asenkron metodu çağırmak için başına await kelimesi koymak zorundayız! içerisinde await kullanılan bir ActionResult metodu da asenkrona çevirilmelidir! Çevirmek için altı kızaran kodun üzerine gelip ampule tıklayıp açılan menüden make method async yi seçmeliyiz
            //var model = databaseContext.Categories.FirstOrDefault(c => c.Id == id);
            // var model = await databaseContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            var model = await databaseContext.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();
            return View(model);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Category collection)
        {
            try
            {
                databaseContext.Categories.Update(collection);
                //databaseContext.SaveChanges();
                await databaseContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return View(await databaseContext.Categories.FindAsync(id));
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                databaseContext.Categories.Remove(collection);
                databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
