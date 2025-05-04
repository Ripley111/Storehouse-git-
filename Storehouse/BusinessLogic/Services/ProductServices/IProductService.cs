using BusinessLogic.DTO;

namespace BusinessLogic.Services.ProductServices
{
    public interface IProductService
    {
        Task CreateAsync(string name, string description, decimal price, CancellationToken cancellationToken = default);

        Task<DTOProduct> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<List<DTOProduct>> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task UpdateAsync(int id, string newName, string newDescriprion, decimal newPrice, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
