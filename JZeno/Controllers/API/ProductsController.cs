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
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NuGet.Protocol;

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
            var products = await _context.Product.Select(e => new
             {
                 Id = e.Id,
                 Name = e.Name,
                 Price = e.Price,
                 Material = e.Material,
                 Description = e.Description,
                 discountPercent = e.DiscountPercent,
                 Image = e.Image!.Select(e => new
                  {
                      Image = e.Image
                  }),
                  color = e.Color!.Select(f => new
                  {  
                      Name = f.Name,
                      productSize = f.ProductSize!.Select(g => new
                      {
                          Size = g.Size,
                          Quantity = g.Quantity,
                      }).ToList()
                  }),
                 category = e.CategoryChild!.CategoryID!.ToString(),
                 categoryChild = e.CategoryChild.Name,
                 categoryChildID = e.CategoryChild.Id,
             }).ToListAsync(); 

          if (_context.Product == null)
          {
              return NotFound();
          }
            return Ok(products);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct(Product product)
        {
            var productIndex = _context.Product!.OrderByDescending(c => c.Index).FirstOrDefault();
            var autoID = productIndex != null ? productIndex.Index + 1 : 1;
            autoID += 1;
            if (autoID == null)
            {
                product.Id = "JZ0001";
            }
            else
            {
                product.Id = "JZ000" + (autoID).ToString();
                if (autoID >= 9)
                {
                 product.Id = "JZ00" + (autoID).ToString();
                }
                if (autoID >= 99)
                {
                    product.Id = "JZ0" + (autoID).ToString();
                }
                if (autoID >= 999)
                {
                    product.Id = "JZ" + (autoID).ToString();
                }
            }

            Product newProduct = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                DiscountPercent = product.DiscountPercent,
                Description = product.Description,
                Color = product.Color.Select(e=> new ProductColor()
                {
                    Name = e.Name,
                    ProductID = product.Id,
                    ProductSize = e.ProductSize!.Select(i => new ProductSize()
                    {
                        Size = i.Size,
                        Quantity = i.Quantity,
                        ColorID = e.Id
                    }).ToList()
                }).ToList(),
                Image = product.Image!.Select(t=> new ProductImage()
                {
                    Image = t.Image,
                    ProductID = product.Id
                }).ToList(),
                Material = product.Material,
                postDate = DateTime.Now,
                CategoryChildID = product.CategoryChildID
            };

            await _context.Product.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return  Ok(newProduct);
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
                image = e.Image.Select(e => new ProductImage()
                {
                    Image = e.Image
                }).ToList(),
                color = e.Color.Select(e => new ProductColor()
                {
                    Name = e.Name,
                    ProductSize = e.ProductSize.Select(e => new ProductSize()
                    {
                        Size = e.Size,
                        Quantity = e.Quantity,
                    }).ToList()
                })
            }).FirstOrDefaultAsync(i => i.id == id);

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
