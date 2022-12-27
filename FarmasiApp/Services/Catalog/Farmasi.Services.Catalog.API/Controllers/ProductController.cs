using Farmasi.Services.Catalog.BL.Dtos.Product;
using Farmasi.Services.Catalog.BL.Services.Abstractions;
using Farmasi.Shared;
using Farmasi.Shared.CustomControllerBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Farmasi.Services.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Response<ProductDto> response = await _productService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productService.GetAllAsync();
            return CreateActionResultInstance(result);
        }

        [AllowAnonymous]
        [HttpPost("pagination")]
        public async Task<IActionResult> GetProductsByPagination([FromBody] ProductListRequestDto productListRequestDto)
        {
            Response<List<ProductDto>> res = await _productService.GetProductListWithPagination(productListRequestDto);
            return CreateActionResultInstance(res);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCreateDto productCreateDto)
        {
            Response<ProductDto> res = await _productService.CreateAsync(productCreateDto);
            return CreateActionResultInstance(res);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            Response<NoContent> res = await _productService.UpdateAsync(productUpdateDto);
            return CreateActionResultInstance(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            Response<NoContent> res = await _productService.DeleteAsync(id);
            return CreateActionResultInstance(res);
        }

    }
}
