using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using X.PagedList;
using YourDressing.Models;
using YourDressing.Models.ViewModels;
using YourDressing.Repositories.Interfaces;

namespace YourDressing.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISectionRepository _sectionRepository;

        public EmployeesController(IEmployeeRepository employeeService, ISectionRepository sectionService)
        {
            _employeeRepository = employeeService;
            _sectionRepository = sectionService;
        }

        public async Task<IActionResult> Index(int? page, string searchString)
        {
            List<Employee> employees;
            if (string.IsNullOrWhiteSpace(searchString))
                employees = await _employeeRepository.GetAllAsync();
            else
            {
                employees = await _employeeRepository.FindByNameAsync(searchString);
                ViewBag.SearchString = searchString;
            }

            return View(await employees.ToPagedListAsync(page ?? 1, 5));
        }

        public async Task<IActionResult> MonthEmployees(int? page)
        {
            List<Employee> employees = await _employeeRepository.GetMonthEmployeesAsync();
            return View(await employees.ToPagedListAsync(page ?? 1, 5));
        }

        public async Task<IActionResult> FiredEmployees(int? page)
        {
            List<Employee> employees = await _employeeRepository.GetFiredEmployeesAsync();
            return View(employees.ToPagedList(page ?? 1, 5));
        }

        public async Task<IActionResult> Create()
        {
            return View(new EmployeeInputViewModel(await _sectionRepository.GetAllAsync()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.InsertAsync(employee);
                return RedirectToAction(nameof(Index));
            }

            return View(new EmployeeInputViewModel(employee, await _sectionRepository.GetAllAsync()));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Employee employee = new();
            try
            {
                employee = await _employeeRepository.FindByIdAsync(id);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }

            return View(new EmployeeInputViewModel(employee, await _sectionRepository.GetAllAsync()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));
            }

            return View(new EmployeeInputViewModel(await _sectionRepository.GetAllAsync()));
        }

        public async Task<IActionResult> Details(int? id)
        {
            Employee employee = new();
            try
            {
                employee = await _employeeRepository.FindByIdAsync(id);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }

            return View(employee);
        }

        public async Task<IActionResult> EmployeeSales(int? id, int? page)
        {
            try
            {
                Employee employee = await _employeeRepository.FindByIdAsync(id);
                ViewBag.EmployeeName = employee.Name;
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }

            List<Sale> sales = await _employeeRepository.GetEmployeeSalesAsync(id.Value);
            return View(await sales.ToPagedListAsync(page ?? 1, 10));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Employee employee = new();
            try
            {
                employee = await _employeeRepository.FindByIdAsync(id);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            string requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View(new ErrorViewModel(requestId,  message));
        }
    }
}
