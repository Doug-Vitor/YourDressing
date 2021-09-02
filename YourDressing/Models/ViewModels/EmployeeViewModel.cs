using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourDressing.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Section> Sections { get; set; }
    }
}
