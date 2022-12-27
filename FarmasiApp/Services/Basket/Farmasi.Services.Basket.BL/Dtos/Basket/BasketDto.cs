using Farmasi.Services.Basket.BL.Dtos.BasketItem;

namespace Farmasi.Services.Basket.BL.Dtos.Basket
{
    public class BasketDto
    {
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice
        {
            get => BasketItems.Sum(x => x.Price * x.Quantity);
        }
    }
}
