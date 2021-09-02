using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YourDressing.Models
{
    public class Employee : Entity
    {
        [DisplayName("Nome completo")]
        [Required(ErrorMessage = "Campo {0} requirido.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Campo {0} deve conter entre {2} e {1} caracteres.")]
        public string Name { get; set; }

        [DisplayName("Data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo {0} requirido")]
        public DateTime Birthdate { get; set; }

        [DisplayName("Salário")]
        public double BaseSalary { get; set; }

        [DisplayName("Empregado do mês")]
        public bool IsMonthEmployee { get; set; }

        public int SectionId { get; set; }

        [DisplayName("Seção")]
        public virtual Section Section { get; set; }
        public virtual List<Sale> Sales { get; set; } = new();

        public Employee()
        {
        }

        public Employee(string name, Section section, DateTime birthdate, double baseSalary, 
            bool isMonthEmployee)
        {
            Name = name;
            Section = section;
            Birthdate = birthdate;
            BaseSalary = baseSalary;
            IsMonthEmployee = isMonthEmployee;
        }

        public void AddSale(Sale sale)
        {
            Sales.Add(sale);
        }
    }
}
