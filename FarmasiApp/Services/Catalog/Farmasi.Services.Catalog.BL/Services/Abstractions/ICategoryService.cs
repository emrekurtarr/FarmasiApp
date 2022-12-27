using Farmasi.Services.Catalog.BL.Dtos.Category;
using Farmasi.Services.Catalog.DAL.Entities;
using Farmasi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
