using Farmasi.Services.Basket.BL.Dtos.Basket;
using Farmasi.Shared;

namespace Farmasi.Services.Basket.BL.Services.Abstractions
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket();

        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);

        Task<Response<bool>> Delete();
    }
}
