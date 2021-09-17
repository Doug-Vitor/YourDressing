using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using YourDressing.Models.Enums;

namespace YourDressing.Models
{
    public class Section : Entity
    {
        [DisplayName("Seção")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        [MaxLength(300)]
        public string Description { get; set; }

        [DisplayName("Situação")]
        public SectionSituation Situation { get; set; }

        public virtual List<Employee> Employees { get; set; } = new();
        public virtual List<Product> Products { get; set; } = new();

        public Section()
        {
        }

        public Section(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void AddEmployees(params Employee[] employees)
        {
            if (employees is null)
                return;

            Employees.AddRange(employees);
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void AddProducts(params Product[] products)
        {
            if (products is null)
                return;

            Products.AddRange(products);
        }

        public double GetTotalProfit()
        {
            double totalProfit = 0;
            foreach (Employee employeeProfit in Employees)
            {
                totalProfit += employeeProfit.GetEmployeeTotalProfit();
            }

            return totalProfit;
        }
    }
}