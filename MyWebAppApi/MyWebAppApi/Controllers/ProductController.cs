using Microsoft.AspNetCore.Mvc;
using MyWebAppApi.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWebAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(BaseProduct product)
        {
            Product p = new Product()
            {
                Id = Guid.NewGuid(),
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
            };
            products.Add(p);

            return Ok(new
            {
                Success = true,
                Data = p
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([Required] string id)
        {
            try
            {
                Product product = products.SingleOrDefault(p => p.Id == Guid.Parse(id));

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([Required] string id, [Required] BaseProduct product)
        {
            Product p = products.SingleOrDefault(p => p.Id == Guid.Parse(id));
            if (p == null)
                return NotFound();

            p.ProductName = product.ProductName;
            p.ProductPrice = product.ProductPrice;

            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById([Required] string id)
        {
            Product p = products.SingleOrDefault(p => p.Id == Guid.Parse(id));
            if (p == null)
                return NotFound();
            products.Remove(p);
            return Ok(p);
        }

    }
}
