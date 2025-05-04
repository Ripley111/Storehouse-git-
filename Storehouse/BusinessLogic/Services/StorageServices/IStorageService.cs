using BusinessLogic.DTO;

namespace BusinessLogic.Services.StorageServices
{
    public interface IStorageService
    {
        Task CreateAsync(string name, string address, CancellationToken cancellationToken = default);

        Task<DTOStorage> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task UpdateAsync(int id, string newName, string newAddress, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellation = default);
    }
}
