using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JZeno.Data;
using JZeno.Models;
using System.Drawing;

namespace JZeno.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var products = await _context.Product.Select(e=> new
            {
                id = e.Id,
                name = e.Name,
                price = e.Price,
                material = e.Material,
                discount = e.DiscountPercent,
                description = e.Description,
                image = e.Image.Select(e => new
                 {
                     name = e.Image
                 }),
                 color = e.Color.Select(e => new
                 {
                     name = e.Name,
                     size = e.ProductSize.Select(e => new
                     {
                         name = e.Size,
                         quantity = e.Quantity,
                     })
                 }),
                category = e.CategoryChild!.CategoryID!.ToString(),
                categoryChild = e.CategoryChild.Name
            }).ToListAsync();
          if (_context.Product == null)
          {
              return NotFound();
          }
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            var product = await _context.Product.Select(e => new
            {
                id = e.Id,
                name = e.Name,
                price = e.Price,
                material = e.Material,
                discount = e.DiscountPercent,
                description = e.Description,
                image = e.Image.Select(e => new
                {
                    name = e.Image
                }).ToList(),
                color = e.Color.Select(e => new
                {
                    name = e.Name,
                    size = e.ProductSize.Select(e => new
                    {
                        name = e.Size,
                        quantity = e.Quantity,
                    })
                })
            }).FirstOrDefaultAsync(i=>i.id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(string id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Product == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
          }
            _context.Product.Add(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(string id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
