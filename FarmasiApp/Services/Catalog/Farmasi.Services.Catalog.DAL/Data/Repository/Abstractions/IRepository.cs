using Farmasi.Services.Catalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T Update(T entity);
        long Delete(string id);
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetAll(Expression<Func<T, bool>>? predicate = null);


    }
}
