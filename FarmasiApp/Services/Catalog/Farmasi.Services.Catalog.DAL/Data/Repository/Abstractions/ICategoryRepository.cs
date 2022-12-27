using Farmasi.Services.Catalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions
{
    public interface ICategoryRepository :IRepository<Category>, IAsyncRepository<Category> 
    {
        //Some special methods belongs to Category
    }
}
