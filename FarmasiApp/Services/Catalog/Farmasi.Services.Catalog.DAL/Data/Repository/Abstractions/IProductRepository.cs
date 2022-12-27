using Farmasi.Services.Catalog.DAL.Entities;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions
{
    public interface IProductRepository : IRepository<Product>, IAsyncRepository<Product> 
    {
        //Some special methods belongs to Product

        IMongoQueryable<Product> GetQuery();
    }
}
