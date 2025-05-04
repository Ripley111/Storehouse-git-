using DataAccess.EFClasses;
using DataAccess.EFCode;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.StorageRepositories
{
    internal class StorageRepository(EFCoreContext appContext) : IStorageRepository
    {
        public async Task CreateAsync(Storage storage, CancellationToken cancellationToken = default)
        {
            await appContext.Storages.AddAsync(storage, cancellationToken);
            await appContext.SaveChangesAsync(cancellationToken);    
        }

        public async Task<Storage?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await appContext.Storages
                .Include(p => p.ProductStorages)
                .ThenInclude(ps => ps.Product)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Storage storage, CancellationToken cancellationToken = default)
        {
            appContext.Storages.Update(storage);
            await appContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Storage storage, CancellationToken cancellationToken = default)
        {
            var hasProduct = await appContext
                .ProductStorages
                .AnyAsync(ps => ps.StorageId == storage.Id && ps.QuantityProduction > 0, cancellationToken);

            if (hasProduct)
                throw new Exception("Storehouse contains products! Removal is not possible!");

            appContext.Storages.Remove(storage);
            await appContext.SaveChangesAsync(cancellationToken);
        }
    }
}
