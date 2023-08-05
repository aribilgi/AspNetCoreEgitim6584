using AspNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var data = await _context.Categories.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return data;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<Category> PostAsync(Category value)
        {
            _context.Categories.Add(value);
            await _context.SaveChangesAsync();

            return value;
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Category value)
        {
            _context.Categories.Update(value);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Categories.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
