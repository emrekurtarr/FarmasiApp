using Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions;
using Farmasi.Services.Catalog.DAL.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Farmasi.Services.Catalog.DAL.Data.Repository.Implementations
{
    public class ProductRepository : GenericBaseRepository<Product>, IProductRepository
    {

        public ProductRepository(IMongoDbContext mongoDbContext) : base(mongoDbContext)
        {

        }

        public IMongoQueryable<Product> GetQuery()
        {
            return _dbCollection.AsQueryable();
        }
    }
}
