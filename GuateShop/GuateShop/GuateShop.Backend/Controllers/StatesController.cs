using GuateShop.Backend.Datos;
using GuateShop.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuateShop.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : ControllerBase 
    {
        private readonly DataContext _context;
        public StatesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.States.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(State state)
        {
            _context.Add(state);
            await _context.SaveChangesAsync();
            return Ok(state);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(State state)
        {
            _context.Update(state);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var state = await _context.States.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
