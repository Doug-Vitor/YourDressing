using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YourDressing.Models.ViewModels;
using YourDressing.Services.Interfaces;

namespace YourDressing.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /* Utilizei boas práticas de orientações a objetos - reuso de código. 
        A partial view "_EmployeesPartial" poderá renderizar todos os funcionários ou apenas funcionários
        do mês e isso será feito conforme a decisão feita aqui. */
        public async Task<IActionResult> Index(string filter)
        {
            HomeViewModel viewModel = new();

            /* A view Index passa o parâmetro filter através da tag helper asp-route-filter de 
            acordo com o que foi definido na propriedade ButtonAction da classe HomeViewModel */
            if (filter == "Month")
            {
                viewModel.Employees = await _employeeService.GetMonthEmployeesAsync();
                viewModel.Title = "Funcionários do mês";
                viewModel.ButtonTitle = "Todos os funcionários";
                viewModel.ButtonAction = "All";
            }
            else
            {
                viewModel.Employees = await _employeeService.FindAllAsync();
                viewModel.Title = "Todos os funcionários";
                viewModel.ButtonTitle = "Funcionários do mês";
                viewModel.ButtonAction = "Month";
            }

            return View(viewModel);
        }
    }
}
