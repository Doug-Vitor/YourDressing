using System.Collections.Generic;

namespace YourDressing.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public virtual List<OrderProducts> OrderProducts { get; set; } = new();
        public double TotalPrice { get; set; }

        public virtual Employee Employee { get; set; }

        public Sale()
        {
        }

        public Sale(Employee employee)
        {
            Employee = employee;
        }
    }
}