namespace BusinessLogic.Services.ProductMoveServices
{
    public interface IProductMoveService
    {
        Task ProductMove(int productId, int storehouseSenderId, int idStorehouseRecipient, int productQuantity, CancellationToken cancellationToken = default);
    }
}
