using Farmasi.Services.Catalog.BL.Dtos.Specification;
using Farmasi.Services.Catalog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
