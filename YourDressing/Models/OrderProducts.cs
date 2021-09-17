using System.ComponentModel;

namespace YourDressing.Models
{
    public class OrderProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [DisplayName("Nome do produto")]
        public virtual Product Product { get; set; }

        [DisplayName("Quantidade")]
        public int Quantity { get; set; }
        public Sale Sale { get; set; }
        
        public OrderProducts()
        {
        }

        public OrderProducts (int productId, Product product, int quantity)
        {
            ProductId = productId;
            Product = product;
            Quantity = quantity;
        }

        public double GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}