using AutoMapper;
using Farmasi.Services.Catalog.BL.Dtos.Category;
using Farmasi.Services.Catalog.BL.Services.Abstractions;
using Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions;
using Farmasi.Services.Catalog.DAL.Entities;
using Farmasi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.BL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;   
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            Category category = _mapper.Map<Category>(categoryCreateDto);
            await _categoryRepo.AddAsync(category);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 201);
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            List<Category> listOfCategories = await _categoryRepo.GetListAsync();

            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(listOfCategories), 200);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            Category category = await _categoryRepo.GetAsync(c => string.Equals(c.Id, id));

            if (category == null)
            {
                return Response<CategoryDto>.Error("Category not found", 404);
            }

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}
