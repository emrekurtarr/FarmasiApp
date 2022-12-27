using Farmasi.Services.Catalog.BL.Dtos.Specification;

namespace Farmasi.Services.Catalog.BL.Dtos.Product
{
    public class ProductUpdateDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public SpecificationDto Specification { get; set; }
        public string CategoryId { get; set; }

    }
}
