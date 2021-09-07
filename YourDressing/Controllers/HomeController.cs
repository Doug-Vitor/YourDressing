using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YourDressing.Repositories.Interfaces;

namespace YourDressing.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeService;

        public HomeController(IEmployeeRepository employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            ViewData["Subtitle2"] = "Confira: funcionários do mês";
            return View(await _employeeService.GetMonthEmployeesAsync());
        }
    }
}
