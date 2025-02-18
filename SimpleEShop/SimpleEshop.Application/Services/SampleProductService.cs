using SimpleEshop.Application.DataTransferObjects;
using SimpleEshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEshop.Application.Services
{
    public class SampleProductService : IProductService
    {
        public List<ProductSummaryDisplay> GetProducts()
        {
            return new()
           {
                new(){ Id=1, Name="Ürün A", Price=1000  },
                new(){ Id=2, Name="Ürün B", Price=2000 },
                new(){ Id=3, Name="Ürün C", Price=3000},
           };
        }
    }
}
