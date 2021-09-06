using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using YourDressing.Services.Interfaces;

namespace YourDressing.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public IPagedList<Employee> PagedEmployees { get; set; }
        public string ButtonTitle { get; set; }
        public string ButtonAction { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; }

        public EmployeeViewModel()
        {
        }

        public async static Task<EmployeeViewModel> DefineFieldsAndReturnViewModel (string filter, 
            string searchString, int? page, List<Employee> employees)
        {
            EmployeeViewModel viewModel = new();
            int pageNumber = page ?? 1;

            switch (filter)
            {
                case "All":
                    viewModel.CurrentFilter = "All";
                    viewModel.ButtonTitle = "Funcionários do mês";
                    viewModel.ButtonAction = "Month";
                    break;
                case "Month":
                    employees = await employees.Where(prop => prop.IsMonthEmployee).ToListAsync();

                    viewModel.CurrentFilter = "Month";
                    viewModel.ButtonTitle = "Todos os funcionários";
                    viewModel.ButtonAction = "All";
                    break;
            }

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                string name = searchString.ToLower();

                employees = await employees.Where(prop => prop.Name.ToLower().Contains(name))
                    .ToListAsync();
                viewModel.SearchString = name;
            }

            viewModel.PagedEmployees = await employees.ToPagedListAsync(pageNumber, 5);
            return viewModel;
        }
    }
}
