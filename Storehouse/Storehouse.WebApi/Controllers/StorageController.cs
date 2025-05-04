using BusinessLogic.Services.StorageServices;
using Microsoft.AspNetCore.Mvc;

namespace Storehouse.WebApi.Controllers
{
    [ApiController]
    [Route("Storehouse")]
    public class StorageController(IStorageService storageService) : ControllerBase
    {
        [HttpPost("createStorehouse", Name = "CreateStorehouse")]
        public async Task<IActionResult> CreateStorehouseAsync(string name, string address)
        {
            await storageService.CreateAsync(name, address);
            return NoContent();
        }

        [HttpGet("getStorehouseById", Name = "GetStorehouseById")]
        public async Task<IActionResult> GetStorehouseByIdAsync(int id)
        {
            var result = await storageService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut("updateStorehouse", Name = "UpdateStorehouse")]
        public async Task<IActionResult> UpdateStorehouseAsync(int id, string? newName, string? newAddress)
        {
            await storageService.UpdateAsync(id, newName, newAddress);
            return NoContent();
        }

        [HttpDelete("deleteStorehouse", Name = "DeleteStorehouse")]
        public async Task<IActionResult> DeleteStorehouseAsync(int id)
        {
            await storageService.DeleteAsync(id);
            return NoContent();
        }
    }
}
