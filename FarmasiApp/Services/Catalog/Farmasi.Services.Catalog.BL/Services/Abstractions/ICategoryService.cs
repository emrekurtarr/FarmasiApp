using Farmasi.Services.Catalog.BL.Dtos.Category;
using Farmasi.Shared;

namespace Farmasi.Services.Catalog.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
