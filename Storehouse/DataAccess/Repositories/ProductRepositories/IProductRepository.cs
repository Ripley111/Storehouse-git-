using DataAccess.EFClasses;

namespace DataAccess.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product, CancellationToken cancellationToken = default);

        Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<List<Product>?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task UpdateAsync(Product product, CancellationToken cancellationToken = default);

        Task DeleteAsync(Product product, CancellationToken cancellationToken = default);
    }
}
