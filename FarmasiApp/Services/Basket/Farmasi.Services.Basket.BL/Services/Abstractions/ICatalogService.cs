using Farmasi.Services.Basket.BL.Dtos.Basket;
using Farmasi.Shared;

namespace Farmasi.Services.Basket.BL.Services.Abstractions
{
    public interface ICatalogService
    {
        Task<Response<BasketDto>> GetProduct();
    }
}
