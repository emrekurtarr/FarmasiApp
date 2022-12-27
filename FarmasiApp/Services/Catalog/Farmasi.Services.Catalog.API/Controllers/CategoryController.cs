using Farmasi.Services.Catalog.BL.Dtos.Category;
using Farmasi.Services.Catalog.BL.Services.Abstractions;
using Farmasi.Shared;
using Farmasi.Shared.CustomControllerBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Farmasi.Services.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            Response<List<CategoryDto>> result = await _categoryService.GetAllAsync();
            var claim = HttpContext.User;
            return CreateActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryCreateDto categoryCreateDto)
        {
            Response<CategoryDto> res = await _categoryService.CreateAsync(categoryCreateDto);
            return CreateActionResultInstance(res);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Response<CategoryDto> res = await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(res);
        }
    }
}
