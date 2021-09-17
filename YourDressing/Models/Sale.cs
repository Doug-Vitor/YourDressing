using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace YourDressing.Models
{
    public class Sale
    {
        [DisplayName("Nº venda")]
        public int Id { get; set; }
        public virtual List<OrderProducts> OrderProducts { get; set; } = new List<OrderProducts>();

        [DisplayName("Preço total")]
        public double TotalPrice { get; set; }

        public int EmployeeId { get; set; }

        [DisplayName("Funcionário responsável")]
        public virtual Employee Employee { get; set; }

        public void SetTotalPrice()
        {
            foreach (OrderProducts products in OrderProducts)
            {
                TotalPrice += products.GetTotalPrice();
            }
        }

        public void AddOrderProduct(OrderProducts orderProducts)
        {
            OrderProducts.Add(orderProducts);
        }
    }
}