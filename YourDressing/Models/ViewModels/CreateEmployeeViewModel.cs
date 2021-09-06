using System.Collections.Generic;

namespace YourDressing.Models.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Section> Sections { get; set; }

        public CreateEmployeeViewModel()
        {
        }

        public CreateEmployeeViewModel(Employee employee)
        {
            Employee = employee;
        }

        public CreateEmployeeViewModel(List<Section> sections)
        {
            Sections = sections;
        }

        public CreateEmployeeViewModel(Employee employee, List<Section> sections) : this(employee)
        {
            Sections = sections;
        }
    }
}
