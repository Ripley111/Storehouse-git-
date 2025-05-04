using DataAccess.EFClasses;
using DataAccess.EFCode;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.ProductRepositories
{
    internal class ProductRepository(EFCoreContext appContext) : IProductRepository
    {
        public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await appContext.Products.AddAsync(product, cancellationToken);
            await appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await appContext.Products
                .Include(p => p.ProductStorages)
                .ThenInclude(ps => ps.Storage)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await appContext.Products
                .Where(p => p.Name == name)
                .Include(p => p.ProductStorages)
                .ThenInclude(ps => ps.Storage)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            appContext.Products.Update(product);
            await appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Product product, CancellationToken cancellationToken = default)
        {
            var hasInStorehouses = await appContext
                .ProductStorages
                .AnyAsync(ps => ps.ProductId == product.Id && ps.QuantityProduction > 0, cancellationToken);

            if (hasInStorehouses)
                throw new Exception("The Product are available in warehouses! Removal is not possible!");

            appContext.Products.Remove(product);
            await appContext.SaveChangesAsync(cancellationToken);
        }
    }
}
