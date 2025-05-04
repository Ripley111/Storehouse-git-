using DataAccess.EFClasses;

namespace DataAccess.Repositories.ProductStorageRepositories
{
    public interface IProductArrivalRepository
    {
        Task ArrivalAsync(ProductStorage productStorage, CancellationToken cancellationToken = default);

        Task<ProductStorage?> GetByIdAsync(int productId, int storehouseId, CancellationToken cancellationToken = default);
    }
}
