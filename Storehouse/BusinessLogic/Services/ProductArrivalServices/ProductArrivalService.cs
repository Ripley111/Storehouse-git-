using DataAccess.EFClasses;
using DataAccess.Repositories.ProductStorageRepositories;

namespace BusinessLogic.Services.ProductArrivalServices
{
    internal class ProductArrivalService(IProductArrivalRepository productArrivalRepository) : IProductArrivalService
    {
        public async Task ArrivalProductAsync(int productId, int storehouseId, int quantityProduct, CancellationToken cancellationToken = default)
        {
            var productInStorage = await productArrivalRepository.GetByIdAsync(productId, storehouseId, cancellationToken);

            if (quantityProduct < 0)
                throw new Exception("Negative quantity of product!");

            if (productInStorage is not null)
            {
                productInStorage.QuantityProduction += quantityProduct;
                await productArrivalRepository.ArrivalAsync(productInStorage, cancellationToken);
            }
            else
            {
                ProductStorage productStorage = new ProductStorage
                {
                    ProductId = productId,
                    StorageId = storehouseId,
                    QuantityProduction = quantityProduct,
                };
                await productArrivalRepository.ArrivalAsync(productStorage, cancellationToken);
            }
        }
    }
}
