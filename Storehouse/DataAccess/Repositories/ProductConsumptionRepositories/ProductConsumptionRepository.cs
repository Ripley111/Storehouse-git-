using DataAccess.EFClasses;
using DataAccess.EFCode;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.ProductConsumptionRepositories
{
    internal class ProductConsumptionRepository(EFCoreContext appContext) : IProductConsumptionRepository
    {
        public async Task ConsumptionAsync(ProductStorage productStorage, CancellationToken cancellationToken = default)
        {
            appContext.Update(productStorage);
            await appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<ProductStorage?> GetByIdAsync(int productId, int storehouseId, CancellationToken cancellationToken = default)
        {
            var product = await appContext
                .Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product is not null)
            {
                var productStorage = await appContext
                    .ProductStorages
                    .FirstOrDefaultAsync(ps => ps.ProductId == productId && ps.StorageId == storehouseId);

                return productStorage;
            }
            else
            {
                throw new Exception("The specified product was not found!");
            }
        }
    }
}
