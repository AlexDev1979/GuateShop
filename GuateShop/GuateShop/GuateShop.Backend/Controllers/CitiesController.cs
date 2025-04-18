﻿using GuateShop.Backend.Datos;
using GuateShop.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuateShop.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly DataContext _context;
        public CitiesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Cities.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(City city)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
            return Ok(city);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(City city)
        {
            _context.Update(city);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
