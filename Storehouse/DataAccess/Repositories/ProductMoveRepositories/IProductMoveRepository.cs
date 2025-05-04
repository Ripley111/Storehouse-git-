using DataAccess.EFClasses;

namespace DataAccess.Repositories.ProductMoveRepositories
{
    public interface IProductMoveRepository
    {
        Task<ProductStorage?> GetProductByIdAsync(int productId, int storehouseId, CancellationToken cancellationToken = default);

        Task MoveProductAsync(ProductStorage productStorage, CancellationToken cancellationToken = default);
    }
}
