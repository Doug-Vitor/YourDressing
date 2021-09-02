using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YourDressing.Models
{
    public class Section : Entity
    {
        [DisplayName("Seção")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        [MaxLength(300)]
        public string Description { get; set; }
        public virtual List<Employee> Employee { get; set; } = new();

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
            Employee.Add(employee);
        }
    }
}