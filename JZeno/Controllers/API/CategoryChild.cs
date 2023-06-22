using JZeno.Data;
using JZeno.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JZeno.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryChildController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryChildController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GetCategoryChild
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryChild>>> GetCategoryChild()
        {
            var categories = await _context.CategoryChild.Select(e => new
            {
                name = e.Id
            }).ToListAsync();
            if (_context.Product == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }
    }
}
