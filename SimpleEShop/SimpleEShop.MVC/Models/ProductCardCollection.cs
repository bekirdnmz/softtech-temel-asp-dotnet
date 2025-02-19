using SimpleEshop.Application.DataTransferObjects;

namespace SimpleEShop.MVC.Models
{
    public class ProductCardCollection
    {
        public List<BasketItem> Items { get; set; } = new();

        public void Add(ProductForBasketItem product)
        {
            var basketItem = Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (basketItem == null)
            {
                Items.Add(new BasketItem() { Product = product, Quantity = 1 });
            }
            else
            {
                basketItem.Quantity++;
            }
        }

        public void Clear()=> Items.Clear();
        public decimal? GetTotalPrice() => Items.Sum(x => x.Product.Price! * x.Quantity);
        public int GetTotalQuantity() => Items.Sum(x => x.Quantity);


    }

    public class  BasketItem
    {
        public ProductForBasketItem Product { get; set; }
        public int Quantity { get; set; }

    }

}
