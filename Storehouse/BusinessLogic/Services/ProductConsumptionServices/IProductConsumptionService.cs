namespace BusinessLogic.Services.ProductConsumptionServices
{
    public interface IProductConsumptionService
    {
        Task ConsumptionProductAsync(int productId, int storehouseId, int quantity, CancellationToken cancellationToken = default);
    }
}
