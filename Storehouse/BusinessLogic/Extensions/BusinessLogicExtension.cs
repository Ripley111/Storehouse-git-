using BusinessLogic.Services.ProductArrivalServices;
using BusinessLogic.Services.ProductConsumptionServices;
using BusinessLogic.Services.ProductMoveServices;
using BusinessLogic.Services.ProductServices;
using BusinessLogic.Services.StorageServices;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Extensions
{
    public static class BusinessLogicExtension
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<IProductArrivalService, ProductArrivalService>();
            serviceCollection.AddScoped<IProductMoveService, ProductMoveService>();
            serviceCollection.AddScoped<IProductConsumptionService, ProductConsumptionService>();

            return serviceCollection;
        }
    }
}
