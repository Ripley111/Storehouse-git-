using DataAccess.Repositories.ProductMoveRepositories;
using DataAccess.EFClasses;

namespace BusinessLogic.Services.ProductMoveServices
{
    internal class ProductMoveService(IProductMoveRepository productMovementRepository) : IProductMoveService
    {
        public async Task ProductMove(int productId, int storehouseSenderId, int storehouseRecipientId, int productQuantity, CancellationToken cancellationToken = default)
        {
            var productInSenderStorage = await productMovementRepository.GetProductByIdAsync(productId, storehouseSenderId, cancellationToken);
            if (productInSenderStorage is not null)
            {
                if (productInSenderStorage.QuantityProduction < productQuantity)
                    throw new Exception("Not enough products!");
                
                var productInRecipienStorage = await productMovementRepository.GetProductByIdAsync(productId, storehouseRecipientId, cancellationToken);
                if(productInRecipienStorage is not null)
                {
                    productInSenderStorage.QuantityProduction -= productQuantity;
                    productInRecipienStorage.QuantityProduction += productQuantity;

                    await productMovementRepository.MoveProductAsync(productInSenderStorage, cancellationToken);
                    await productMovementRepository.MoveProductAsync(productInRecipienStorage, cancellationToken);
                }
                else
                {
                    productInSenderStorage.QuantityProduction -= productQuantity;

                    productInRecipienStorage = new ProductStorage
                    {
                        ProductId = productId,
                        StorageId = storehouseRecipientId,
                        QuantityProduction = productQuantity
                    };

                    await productMovementRepository.MoveProductAsync(productInSenderStorage, cancellationToken);
                    await productMovementRepository.MoveProductAsync(productInRecipienStorage, cancellationToken);
                }
            }
            else
            {
                throw new Exception("The specified storehouse was not found!");
            }
        }
    }
}
