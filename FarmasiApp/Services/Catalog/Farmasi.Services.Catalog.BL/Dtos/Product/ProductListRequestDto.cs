using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Catalog.BL.Dtos.Product
{
    public class ProductListRequestDto
    {
        public string CategoryId { get; set; }
        public OrderBy? OrderBy { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        
    }
    public enum OrderBy
    {
        PriceAsc,
        PriceDesc
    }
}
