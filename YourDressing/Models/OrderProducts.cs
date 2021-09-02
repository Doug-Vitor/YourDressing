namespace YourDressing.Models
{
    public class OrderProducts
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public virtual Sale Sale { get; set; }

        public OrderProducts()
        {
        }

        public OrderProducts(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}