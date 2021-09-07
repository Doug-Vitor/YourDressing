using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using YourDressing.Models.Enums;

namespace YourDressing.Models
{
    public class Employee : Entity
    {
        [DisplayName("Nome completo")]
        [Required(ErrorMessage = "O campo {0} é requirido.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        public string Name { get; set; }

        [DisplayName("Data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "O campo {0} é requirido")]
        public DateTime Birthdate { get; set; }

        [DisplayName("Situação")]
        public EmployeeSituation Situation { get; set; }

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

        public Employee(string name, DateTime birthdate, Section section)
        {
            Name = name;
            Birthdate = birthdate;
            Section = section;
        }

        public void AddSale(Sale sale)
        {
            Sales.Add(sale);
        }
    }
}
