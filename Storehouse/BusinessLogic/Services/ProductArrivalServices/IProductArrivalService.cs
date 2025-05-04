namespace BusinessLogic.Services.ProductArrivalServices
{
    public interface IProductArrivalService
    {
        Task ArrivalProductAsync(int productId, int storehouseId, int quantity, CancellationToken cancellationToken = default);
    }
}
