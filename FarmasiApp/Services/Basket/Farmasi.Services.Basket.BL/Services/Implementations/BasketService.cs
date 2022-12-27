using Farmasi.Services.Basket.BL.Dtos.Basket;
using Farmasi.Services.Basket.BL.Services.Abstractions;
using Farmasi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Farmasi.Services.Basket.BL.Services.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete()
        {
            var status = await _redisService.GetDb().KeyDeleteAsync("FarmasiBasket");
            return status ? Response<bool>.Success(204) : Response<bool>.Error("Basket not found", 404);
        }

        public async Task<Response<BasketDto>> GetBasket()
        {
            var existBasket = await _redisService.GetDb().StringGetAsync("FarmasiBasket");

            if (String.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Error("Basket not found", 404);
            }

            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync("FarmasiBasket", JsonSerializer.Serialize(basketDto));

            return status ? Response<bool>.Success(204) : Response<bool>.Error("Basket could not update or save", 500);
        }
    }
}
