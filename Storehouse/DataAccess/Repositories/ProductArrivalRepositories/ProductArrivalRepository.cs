using DataAccess.EFClasses;
using DataAccess.EFCode;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.ProductStorageRepositories
{
    internal class ProductArrivalRepository(EFCoreContext appContext) : IProductArrivalRepository
    {
        public async Task ArrivalAsync(ProductStorage productStorage, CancellationToken cancellationToken = default)
        {
            var productInStorage = await appContext
                .ProductStorages
                .FirstOrDefaultAsync(ps => ps.ProductId == productStorage.ProductId && ps.StorageId == productStorage.StorageId);

            if (productInStorage is not null)
            {
                appContext.ProductStorages.Update(productStorage);
                await appContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                await appContext.ProductStorages.AddAsync(productStorage, cancellationToken);
                await appContext.SaveChangesAsync(cancellationToken);
            }                
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
