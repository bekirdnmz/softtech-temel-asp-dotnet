using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEshop.Application.DataTransferObjects
{
    public class ProductForBasketItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public string? ImageUrl { get; set; }



    }
}
