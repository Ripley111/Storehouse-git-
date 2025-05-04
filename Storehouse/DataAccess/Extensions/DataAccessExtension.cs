using DataAccess.EFCode;
using DataAccess.Repositories.ProductConsumptionRepositories;
using DataAccess.Repositories.ProductMoveRepositories;
using DataAccess.Repositories.ProductRepositories;
using DataAccess.Repositories.ProductStorageRepositories;
using DataAccess.Repositories.StorageRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions
{
    public static class DataAccessExtension
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<IStorageRepository, StorageRepository>();
            serviceCollection.AddScoped<IProductArrivalRepository, ProductArrivalRepository>();
            serviceCollection.AddScoped<IProductMoveRepository, ProductMoveRepository>();
            serviceCollection.AddScoped<IProductConsumptionRepository, ProductConsumptionRepository>();

            serviceCollection.AddDbContext<EFCoreContext>(x =>
            {
                x.UseNpgsql("Host=localhost;DataBase=StoreHouseDB;Username=postgres;Password=12345");
            });
            return serviceCollection;
        }
    }
}
