using DataAccess.Repositories.ProductConsumptionRepositories;

namespace BusinessLogic.Services.ProductConsumptionServices
{
    internal class ProductConsumptionService(IProductConsumptionRepository productConsumptionRepository) : IProductConsumptionService
    {
        public async Task ConsumptionProductAsync(int productId, int storehouseId, int quantity, CancellationToken cancellationToken = default)
        {
            var productInStorage = await productConsumptionRepository.GetByIdAsync(productId, storehouseId, cancellationToken);
            if(productInStorage is not null)
            {
                if (productInStorage.QuantityProduction < quantity)
                    throw new Exception("Not enough products!");

                productInStorage.QuantityProduction -= quantity;

                await productConsumptionRepository.ConsumptionAsync(productInStorage, cancellationToken);
            }
            else
            {
                throw new Exception("The product will not be found!");
            }
        }
    }
}
