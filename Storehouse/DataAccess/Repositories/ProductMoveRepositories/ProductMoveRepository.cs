using DataAccess.EFClasses;
using DataAccess.EFCode;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.ProductMoveRepositories
{
    internal class ProductMoveRepository(EFCoreContext appContext) : IProductMoveRepository
    {
        public async Task<ProductStorage?> GetProductByIdAsync(int productId, int storehouseId,CancellationToken cancellationToken = default)
        {
            return await appContext
                .ProductStorages
                .FirstOrDefaultAsync(ps => ps.ProductId == productId && ps.StorageId == storehouseId);
        }

        public async Task MoveProductAsync(ProductStorage productStorage, CancellationToken cancellationToken = default)
        {
            var productInStorage =  await appContext
                .ProductStorages
                .FirstOrDefaultAsync(ps => ps.ProductId == productStorage.ProductId && ps.StorageId == productStorage.StorageId);

            if (productInStorage is not null)
            {
                appContext.Update(productStorage);
                await appContext.SaveChangesAsync(cancellationToken);
            }
            else
            {
                await appContext.AddAsync(productStorage, cancellationToken);
                await appContext.SaveChangesAsync(cancellationToken);
            }            
        }
    }
}
