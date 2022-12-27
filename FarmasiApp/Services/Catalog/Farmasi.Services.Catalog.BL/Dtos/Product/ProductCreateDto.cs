using Farmasi.Services.Catalog.BL.Dtos.Specification;

namespace Farmasi.Services.Catalog.BL.Dtos.Product
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public SpecificationDto Specification { get; set; }
        public string CategoryId { get; set; }
    }
}
