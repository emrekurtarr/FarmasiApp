using Farmasi.Services.Catalog.BL.Dtos.Product;
using Farmasi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.BL.Services.Abstractions
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();
        Task<Response<ProductDto>> GetByIdAsync(string id);
        Task<Response<ProductDto>> CreateAsync(ProductCreateDto productCreateDto);
        Task<Response<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
        Task<Response<List<ProductDto>>> GetProductListWithPagination(ProductListRequestDto productListRequestDto);
    }
}
