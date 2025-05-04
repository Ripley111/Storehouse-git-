using BusinessLogic.Services.ProductArrivalServices;
using Microsoft.AspNetCore.Mvc;

namespace Storehouse.WebApi.Controllers
{
    [ApiController]
    [Route("Arrival")]
    public class ProductArrivalController(IProductArrivalService productArrivalService) : ControllerBase
    {
        [HttpPost("productArrival", Name = "ProductArrival")]
        public async Task<IActionResult> ProductArrivalAsync(int productId, int storehouseId, int productQuantity)
        {
            await productArrivalService.ArrivalProductAsync(productId, storehouseId, productQuantity);
            return NoContent();
        }
    }
}
