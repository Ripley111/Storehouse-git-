using BusinessLogic.DTO;
using DataAccess.EFClasses;
using DataAccess.Repositories.ProductRepositories;
using System.Threading;

namespace BusinessLogic.Services.ProductServices
{
    internal class ProductService(IProductRepository productRepository) : IProductService
    {
        public async Task CreateAsync(string name, string description, decimal price, CancellationToken cancellationToken = default)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price
            };

            await productRepository.CreateAsync(product, cancellationToken);
        }

        public async Task<DTOProduct> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByIdAsync(id, cancellationToken);

            if (product is null)
                throw new Exception("Product not found!");

            return new DTOProduct
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StorageInforamation = product.ProductStorages.Select(ps => new DTOProduct.StorageInfo
                {
                    StorageName = ps.Storage.Name,
                    ProductQuantity = ps.QuantityProduction,
                    StorageAddress = ps.Storage.Address
                })
                .ToList()
            };
        }

        public async Task<List<DTOProduct>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByNameAsync(name, cancellationToken);

            if (product is null)
                throw new Exception("Product not found!");

            return product.Select(p => new DTOProduct
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StorageInforamation = p.ProductStorages.Select(ps => new DTOProduct.StorageInfo
                {
                    StorageName = ps.Storage.Name,
                    StorageAddress = ps.Storage.Address,
                    ProductQuantity = ps.QuantityProduction
                })
                .ToList()
            })
            .ToList();
        }

        public async Task UpdateAsync(int id, string newName, string newDescription, decimal newPrice, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByIdAsync(id, cancellationToken);

            if (product is null)
                throw new Exception("Product not found!");
            
            product.Name = newName ?? product.Name;
            product.Description = newDescription ?? product.Description;
            product.Price = (newPrice == 0) ? product.Price : newPrice;

            await productRepository.UpdateAsync(product, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await productRepository.GetByIdAsync(id, cancellationToken);

            if (product is null)
                throw new Exception("Product not found!");

            await productRepository.DeleteAsync(product, cancellationToken);
        }
    }
}
