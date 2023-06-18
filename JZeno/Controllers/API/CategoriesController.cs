using JZeno.Data;
using JZeno.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JZeno.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            var categories = await _context.Category.Select(e => new
            {
               idParent = e.Id,
               name = e.Name
            }).ToListAsync();
            if (_context.Product == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }
    }
}
