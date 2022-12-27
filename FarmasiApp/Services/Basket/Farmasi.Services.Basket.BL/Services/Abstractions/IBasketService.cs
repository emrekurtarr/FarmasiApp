using Farmasi.Services.Basket.BL.Dtos.Basket;
using Farmasi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Basket.BL.Services.Abstractions
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket();

        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);

        Task<Response<bool>> Delete();
    }
}
