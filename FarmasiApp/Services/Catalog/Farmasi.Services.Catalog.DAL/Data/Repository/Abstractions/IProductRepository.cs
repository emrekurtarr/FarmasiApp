using Farmasi.Services.Catalog.DAL.Entities;
using MongoDB.Driver.Linq;

namespace Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions
{
    public interface IProductRepository : IRepository<Product>, IAsyncRepository<Product>
    {
        //Some special methods belongs to Product

        IMongoQueryable<Product> GetQuery();
    }
}
