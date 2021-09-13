using Microsoft.AspNetCore.Mvc.Rendering;

namespace YourDressing.Models.ViewModels
{
    public class SaleInputViewModel
    {
        public Sale Sale { get; set; }
        public int ItemsQuantity { get; set; }
        public SelectList Products { get; set; }

        public SaleInputViewModel()
        {
        }

        public SaleInputViewModel(int itemsQuantity, SelectList products)
        {
            ItemsQuantity = itemsQuantity;
            Products = products;
        }

        public SaleInputViewModel(Sale sale, int itemsQuantity, SelectList products)
        {
            Sale = sale;
            ItemsQuantity = itemsQuantity;
            Products = products;
        }
    }
}
