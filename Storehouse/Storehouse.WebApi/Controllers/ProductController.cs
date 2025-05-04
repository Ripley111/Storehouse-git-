using BusinessLogic.Services.ProductServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Storehouse.WebApi.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpPost("createProduct", Name = "CreateProduct")]
        public async Task<IActionResult> CreateProductAsync(string name, string description, decimal price)
        {
            await productService.CreateAsync(name, description, price);
            return NoContent();
        }

        [HttpGet("getProductById", Name = "GetProductById")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var result = await productService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("getProductByName", Name = "GetProductByName")]
        public async Task<IActionResult> GetProductByNameAsync(string name)
        {
            var result = await productService.GetByNameAsync(name);
            return Ok(result);
        }

        [HttpPut("updateProduct", Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync(int id, string? newName, string? newDescription, decimal newPrice)
        {
            await productService.UpdateAsync(id, newName, newDescription, newPrice);
            return NoContent();
        }

        [HttpDelete("deleteProduct", Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            await productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
