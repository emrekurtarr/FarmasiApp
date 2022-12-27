using Farmasi.Services.Basket.API.Dtos;
using Farmasi.Services.Basket.API.Helpers;
using Farmasi.Services.Basket.BL.Dtos.Basket;
using Farmasi.Services.Basket.BL.Dtos.BasketItem;
using Farmasi.Services.Basket.BL.Services.Abstractions;
using Farmasi.Services.Basket.DAL.Entities;
using Farmasi.Shared;
using Farmasi.Shared.CustomControllerBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Farmasi.Services.Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _basketService.GetBasket());
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket()
        {
            Response<List<ProductDto>> res = await HttpHelper.Get<Response<List<ProductDto>>>("http://localhost:5011/api/product");
            ProductDto productDto = res.Data.FirstOrDefault();
            
            if(productDto != null)
            {
                    
                BasketItemDto basketItem = new BasketItemDto();
                basketItem.ProductId = productDto.Id;
                basketItem.ProductName = productDto.Name;
                basketItem.Price = productDto.Price;

                List<BasketItemDto> basketItemList = new List<BasketItemDto> { basketItem };

                var response = await _basketService.SaveOrUpdate(new BasketDto { BasketItems = basketItemList  });

                return CreateActionResultInstance(response);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()

        {
            return CreateActionResultInstance(await _basketService.Delete());
        }

    }
}
