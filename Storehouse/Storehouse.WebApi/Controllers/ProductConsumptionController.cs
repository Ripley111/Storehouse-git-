using BusinessLogic.Services.ProductConsumptionServices;
using Microsoft.AspNetCore.Mvc;

namespace Storehouse.WebApi.Controllers
{
    [ApiController]
    [Route("Consumption")]
    public class ProductConsumptionController(IProductConsumptionService productConsumptionService) : ControllerBase
    {
        [HttpPut("productConsumption", Name = "ProductConsumption")]
        public async Task<IActionResult> ConsumptionProductAsync(int productId, int storehouseId, int productQuantity)
        {
            await productConsumptionService.ConsumptionProductAsync(productId, storehouseId, productQuantity);
            return NoContent();
        }
    }
}
