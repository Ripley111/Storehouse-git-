using BusinessLogic.Services.ProductMoveServices;
using Microsoft.AspNetCore.Mvc;

namespace Storehouse.WebApi.Controllers
{
    [ApiController]
    [Route("Movement")]
    public class ProductMovementController(IProductMoveService productMoveService) : ControllerBase
    {
        [HttpPut("productMove", Name = "ProductMove")]
        public async Task<IActionResult> ProductMoveAsync(int productId, int storehouseSenderId, int storehouseRecipientId, int productQuantity)
        {
            await productMoveService.ProductMove(productId, storehouseSenderId, storehouseRecipientId, productQuantity);
            return NoContent();
        }
    }
}
