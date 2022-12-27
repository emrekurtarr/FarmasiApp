using Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions;
using Farmasi.Services.Catalog.DAL.Entities;

namespace Farmasi.Services.Catalog.DAL.Data.Repository.Implementations
{
    public class CategoryRepository : GenericBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoDbContext mongoDbContext) : base(mongoDbContext)
        {

        }
    }
}
