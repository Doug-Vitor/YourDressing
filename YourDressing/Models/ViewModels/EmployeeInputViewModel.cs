using System.Collections.Generic;

namespace YourDressing.Models.ViewModels
{
    public class EmployeeInputViewModel
    {
        public Employee Employee { get; set; }
        public List<Section> Sections { get; set; }

        public EmployeeInputViewModel()
        {
        }

        public EmployeeInputViewModel(Employee employee)
        {
            Employee = employee;
        }

        public EmployeeInputViewModel(List<Section> sections)
        {
            Sections = sections;
        }

        public EmployeeInputViewModel(Employee employee, List<Section> sections) : this(employee)
        {
            Sections = sections;
        }
    }
}
