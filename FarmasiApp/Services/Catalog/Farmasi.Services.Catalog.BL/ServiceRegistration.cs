using Farmasi.Services.Catalog.BL.Services.Abstractions;
using Farmasi.Services.Catalog.BL.Services.Implementations;
using Farmasi.Services.Catalog.DAL.Data;
using Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions;
using Farmasi.Services.Catalog.DAL.Data.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.BL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection RegisterMongoDbContext(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDbContext, MongoDbContext>();

            return services;
        }


    }
}
