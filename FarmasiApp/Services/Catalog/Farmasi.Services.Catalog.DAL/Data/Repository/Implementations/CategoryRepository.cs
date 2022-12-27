using Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions;
using Farmasi.Services.Catalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.DAL.Data.Repository.Implementations
{
    public class CategoryRepository : GenericBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoDbContext mongoDbContext) : base(mongoDbContext)
        {

        }
    }
}
