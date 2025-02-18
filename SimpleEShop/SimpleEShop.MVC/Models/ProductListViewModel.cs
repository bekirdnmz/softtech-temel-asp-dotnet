using SimpleEshop.Application.DataTransferObjects;
using SimpleEshop.Domain;

namespace SimpleEShop.MVC.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductSummaryDisplay> Products { get; set; }
        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }
    }
}
