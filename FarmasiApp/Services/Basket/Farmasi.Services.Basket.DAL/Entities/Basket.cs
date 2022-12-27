using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.Services.Basket.DAL.Entities
{
    public class Basket
    {
        public List<BasketItem> BasketItems { get; set; }
        public decimal TotalPrice 
        {
            get => BasketItems.Sum(x => (x.Price * x.Quantity)); 
        }
    }
}
