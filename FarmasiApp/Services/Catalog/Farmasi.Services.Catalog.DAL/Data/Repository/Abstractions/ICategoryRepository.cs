using Farmasi.Services.Catalog.DAL.Entities;

namespace Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions
{
    public interface ICategoryRepository : IRepository<Category>, IAsyncRepository<Category>
    {
        //Some special methods belongs to Category
    }
}
