using Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions;
using Farmasi.Services.Catalog.DAL.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.DAL.Data.Repository.Implementations
{
    public class ProductRepository : GenericBaseRepository<Product>, IProductRepository
    {

        public ProductRepository(IMongoDbContext mongoDbContext):base(mongoDbContext)
        {

        }

        public IMongoQueryable<Product> GetQuery()
        {
            return _dbCollection.AsQueryable();
        }
    }
}
