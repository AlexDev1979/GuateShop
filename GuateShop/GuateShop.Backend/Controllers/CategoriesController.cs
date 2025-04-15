using GuateShop.Backend.Data;
using GuateShop.Share.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuateShop.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.categorias.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var category = await _context.categorias.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Categoria category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(Categoria category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _context.categorias.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.categorias.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
