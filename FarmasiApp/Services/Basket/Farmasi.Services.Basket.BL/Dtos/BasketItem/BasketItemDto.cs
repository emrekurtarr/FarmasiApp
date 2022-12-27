namespace Farmasi.Services.Basket.BL.Dtos.BasketItem
{
    public class BasketItemDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
    }
}
