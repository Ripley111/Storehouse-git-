using DataAccess.EFClasses;

namespace DataAccess.Repositories.StorageRepositories
{
    public interface IStorageRepository
    {
        Task CreateAsync(Storage storage, CancellationToken cancellationToken = default);

        Task<Storage?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task UpdateAsync(Storage storage, CancellationToken cancellationToken = default);

        Task DeleteAsync(Storage storage, CancellationToken cancellationToken = default);
    }
}
