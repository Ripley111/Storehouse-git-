using BusinessLogic.DTO;
using DataAccess.EFClasses;
using DataAccess.Repositories.StorageRepositories;

namespace BusinessLogic.Services.StorageServices
{
    internal class StorageService(IStorageRepository storageRepository) : IStorageService
    {
        public async Task CreateAsync(string name, string address, CancellationToken cancellationToken = default)
        {
            var storage = new Storage
            {
                Name = name,
                Address = address
            };

            await storageRepository.CreateAsync(storage, cancellationToken);
        }

        public async Task<DTOStorage> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var storage = await storageRepository.GetByIdAsync(id, cancellationToken);

            if (storage is null)
                throw new Exception("Storage not found!");

            return new DTOStorage
            {
                Name = storage.Name,
                Address = storage.Address,
                ProductsInfo = storage.ProductStorages.Select(ps => new DTOStorage.ProductInfo
                {
                    ProductName = ps.Product.Name,
                    ProductPrice = ps.Product.Price,
                    ProductQuantity = ps.QuantityProduction
                })
                .ToList()
            };
        }

        public async Task UpdateAsync(int id, string newName, string newAddress, CancellationToken cancellationToken = default)
        {
            var storage = await storageRepository.GetByIdAsync(id, cancellationToken);

            if (storage is null)
                throw new Exception("Storage not found!");

            storage.Name = newName ?? storage.Name;
            storage.Address = newAddress ?? storage.Address;

            await storageRepository.UpdateAsync(storage, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var storage = await storageRepository.GetByIdAsync(id, cancellationToken);

            if (storage is null)
                throw new Exception("Storage not found!");

            await storageRepository.DeleteAsync(storage, cancellationToken);
        }
    }
}
