using DataAccess.EFClasses;

namespace DataAccess.Repositories.ProductConsumptionRepositories
{
    public interface IProductConsumptionRepository
    {
        Task ConsumptionAsync(ProductStorage productStorage, CancellationToken cancellationToken = default);

        Task<ProductStorage?> GetByIdAsync(int productId, int storehouseId, CancellationToken cancellationToken = default);
    }
}
