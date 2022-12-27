using Farmasi.Services.Basket.BL.Dtos.Basket;
using Farmasi.Services.Basket.BL.Services.Abstractions;
using Farmasi.Shared;
using Farmasi.Shared.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace Farmasi.Services.Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ICatalogService _catalogService;

        public BasketController(IBasketService basketService, ICatalogService catalogService)
        {
            _basketService = basketService;
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _basketService.GetBasket());
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket()
        {
            Response<BasketDto> response = await _catalogService.GetProduct();

            if (response.Data is null)
            {
                return NoContent();
            }

            var result = await _basketService.SaveOrUpdate(response.Data);
            return CreateActionResultInstance(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            return CreateActionResultInstance(await _basketService.Delete());
        }

    }
}
