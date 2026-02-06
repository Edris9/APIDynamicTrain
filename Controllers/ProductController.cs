using Microsoft.AspNetCore.Mvc;
using MinForstaApi.Models;

namespace MinForstaApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 9999 },
            new Product { Id = 2, Name = "Mobil", Price = 5999 }
        };

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            product.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;
            products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Update(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            products.Remove(product);
            return NoContent();
        }
    }
}