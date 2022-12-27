namespace Farmasi.Services.Basket.BL.Dtos.Product
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public SpecificationDto Specification { get; set; }
        public string CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }

    public class SpecificationDto
    {
        public string Usage { get; set; }

    }

    public class CategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
