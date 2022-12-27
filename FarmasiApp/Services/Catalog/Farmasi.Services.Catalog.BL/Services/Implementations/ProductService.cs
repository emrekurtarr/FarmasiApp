using AutoMapper;
using Farmasi.Services.Catalog.BL.Dtos.Product;
using Farmasi.Services.Catalog.BL.Services.Abstractions;
using Farmasi.Services.Catalog.DAL.Data.Repository.Abstractions;
using Farmasi.Services.Catalog.DAL.Entities;
using Farmasi.Shared;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Farmasi.Services.Catalog.BL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Response<ProductDto>> CreateAsync(ProductCreateDto productCreateDto)
        {
            Product addedproduct = _mapper.Map<Product>(productCreateDto);
            addedproduct.CreatedAt = DateTime.Now;

            await _productRepository.AddAsync(addedproduct);

            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(addedproduct), 201);

        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            long deletedCount = await _productRepository.DeleteAsync(id);

            if (deletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Error("Product not found", 404);
            }
        }

        public async Task<Response<List<ProductDto>>> GetAllAsync()
        {
            List<Product> products = await _productRepository.GetListAsync();
            List<Category> categories = await _categoryRepository.GetListAsync();

            if (products.Any())
            {
                if (categories.Any())
                {
                    foreach (Product product in products)
                    {
                        product.Category = categories.FirstOrDefault<Category>(c => c.Id == product.CategoryId);
                    }
                }
            }

            return Response<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
        }

        public async Task<Response<ProductDto>> GetByIdAsync(string id)
        {
            Product product = await _productRepository.GetAsync(x => string.Equals(x.Id, id));
            if (product == null)
            {
                return Response<ProductDto>.Error("Product not found", 404);
            }

            product.Category = await _categoryRepository.GetAsync(c => string.Equals(c.Id, product.CategoryId));
            return Response<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }

        public async Task<Response<List<ProductDto>>> GetProductListWithPagination(ProductListRequestDto productListRequestDto)
        {
            IMongoQueryable<Product> query = _productRepository.GetQuery();

            if (string.IsNullOrEmpty(productListRequestDto.CategoryId))
            {
                query = query.Where(x => string.Equals(x.CategoryId, productListRequestDto.CategoryId));
            }
            if (productListRequestDto.OrderBy != null)
            {
                query = productListRequestDto.OrderBy switch
                {
                    OrderBy.PriceAsc => query = query.OrderBy(x => x.Price),
                    OrderBy.PriceDesc => query = query.OrderByDescending(x => x.Price),
                    _ => query
                };
            }
            List<Product> products = await query.Skip((productListRequestDto.PageIndex - 1) * productListRequestDto.PageSize).Take(productListRequestDto.PageSize).ToListAsync();
            List<ProductDto> productListDto = _mapper.Map<List<ProductDto>>(products);


            return Response<List<ProductDto>>.Success(productListDto, 200);
        }

        public async Task<Response<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var updatedProduct = _mapper.Map<Product>(productUpdateDto);
            Product result = await _productRepository.UpdateAsync(updatedProduct);

            if (result == null)
                return Response<NoContent>.Error("Product not found", 404);

            return Response<NoContent>.Success(204);
        }
    }
}
