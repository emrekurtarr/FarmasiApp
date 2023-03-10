using Farmasi.Services.Catalog.BL.Dtos.Category;
using Farmasi.Services.Catalog.BL.Dtos.Specification;

namespace Farmasi.Services.Catalog.BL.Dtos.Product
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
}
