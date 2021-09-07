using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using YourDressing.Models.Enums;

namespace YourDressing.Models
{
    public class Section : Entity
    {
        [DisplayName("Seção")]
        [Required(ErrorMessage = "O campo {0} é requirido.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é requirido.")]
        [MaxLength(300)]
        public string Description { get; set; }

        [DisplayName("Situação")]
        public SectionSituation Situation { get; set; }

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