using SimpleEshop.Application.DataTransferObjects;

namespace SimpleEshop.API.MVCTemplate.Models
{
    public class ProductSearchResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<ProductSummaryDisplay> Products { get; set; }
        public string SearchTerm { get; set; }
        public string Message { get; set; }

    }
}
