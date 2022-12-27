using Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions;
using Farmasi.Services.Catalog.DAL.Entities;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Farmasi.Services.Catalog.DAL.Data.Repository.Implementations
{
    public class GenericBaseRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _dbCollection;
        public GenericBaseRepository(IMongoDbContext mongoDbContext)
        {
            _dbCollection = mongoDbContext.GetCollection<T>(typeof(T).Name);
        }
        public T Add(T entity)
        {
            _dbCollection.InsertOne(entity);
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbCollection.InsertOneAsync(entity);
            return entity;
        }

        public long Delete(string id)
        {
            DeleteResult result = _dbCollection.DeleteOne(x => string.Equals(id, x.Id));

            if (result.DeletedCount > 0)
            {
                return result.DeletedCount;
            }
            else
            {
                return -1;
            }
        }

        public async Task<long> DeleteAsync(string id)
        {
            DeleteResult result = await _dbCollection.DeleteOneAsync(c => string.Equals(c.Id, id));

            if (result.DeletedCount > 0)
            {
                return result.DeletedCount;
            }
            else
            {
                return -1;
            }
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbCollection.Find(predicate).FirstOrDefault();
        }

        public List<T> GetAll(Expression<Func<T, bool>>? predicate = null)
        {
            return predicate == null ?
                   _dbCollection.Find(entity => true).ToList() :
                   _dbCollection.Find(predicate).ToList();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbCollection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null)
                return await _dbCollection.Find(entity => true).ToListAsync();
            else
                return await _dbCollection.Find(predicate).ToListAsync();
        }

        public T Update(T entity)
        {
            T result = _dbCollection.FindOneAndReplace(x => string.Equals(entity.Id, x.Id), entity);
            return result;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            T result = await _dbCollection.FindOneAndReplaceAsync(x => string.Equals(entity.Id, x.Id), entity);
            return result;
        }


    }
}
