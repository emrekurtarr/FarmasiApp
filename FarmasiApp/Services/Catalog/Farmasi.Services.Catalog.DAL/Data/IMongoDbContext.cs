using MongoDB.Driver;

namespace Farmasi.Services.Catalog.DAL.Data
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
