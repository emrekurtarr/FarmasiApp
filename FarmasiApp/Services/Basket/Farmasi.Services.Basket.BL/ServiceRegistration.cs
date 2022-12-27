using Farmasi.Services.Basket.BL.Services.Abstractions;
using Farmasi.Services.Basket.BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Farmasi.Services.Basket.BL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IBasketService, BasketService>();

            return services;
        }



    }
}
