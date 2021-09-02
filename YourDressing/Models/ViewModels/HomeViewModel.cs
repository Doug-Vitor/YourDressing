using System.Collections.Generic;

namespace YourDressing.Models.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; } // Título da view.
        public string ButtonTitle { get; set; } // Título do botão.
        public string ButtonAction { get; set; } // Parâmetro a ser passado na tag helper asp-route-filter, de acordo com o que foi definido no ButtonTitle.
        public List<Employee> Employees { get; set; }
    }
}
