using Farmasi.Services.Basket.BL.Dtos.Basket;
using Farmasi.Services.Basket.BL.Dtos.BasketItem;
using Farmasi.Services.Basket.BL.Dtos.Product;
using Farmasi.Services.Basket.BL.Helpers;
using Farmasi.Services.Basket.BL.Services.Abstractions;
using Farmasi.Shared;

namespace Farmasi.Services.Basket.BL.Services.Implementations
{
    public class CatalogService : ICatalogService
    {
        public CatalogService()
        {

        }
        public async Task<Response<BasketDto>> GetProduct()
        {
            Response<List<ProductDto>> res = await HttpHelper.Get<Response<List<ProductDto>>>("http://localhost:5011/api/product");

            if (res.Data is null)
            {
                return Response<BasketDto>.Error("Product not found", 404);
            }

            ProductDto productDto = res.Data.FirstOrDefault();

            if (productDto is not null)
            {
                BasketItemDto basketItem = new BasketItemDto
                {
                    ProductId = productDto.Id,
                    ProductName = productDto.Name,
                    Price = productDto.Price
                };

                List<BasketItemDto> basketItemList = new List<BasketItemDto> { basketItem };

                BasketDto basketDto = new BasketDto { BasketItems = basketItemList };
                return Response<BasketDto>.Success(basketDto, 200);
            }

            return Response<BasketDto>.Error("Product not found", 404);

        }
    }
}
