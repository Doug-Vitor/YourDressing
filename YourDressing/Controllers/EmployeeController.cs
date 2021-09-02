using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using YourDressing.Models;
using YourDressing.Models.ViewModels;
using YourDressing.Services.Exceptions;
using YourDressing.Services.Interfaces;

namespace YourDressing.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ISectionService _sectorService;

        public EmployeeController(IEmployeeService employeeService, ISectionService sectorService)
        {
            _employeeService = employeeService;
            _sectorService = sectorService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Todos os funcionários";
            ViewData["Subtitle2"] = "Todos os funcionários";

            return View(await _employeeService.FindAllAsync());
        }

        public async Task<IActionResult> Create()
        {
            List<Section> sectors = await _sectorService.FindAllAsync();
            EmployeeViewModel viewModel = new() { Sections = sectors };

            ViewData["Title"] = "Administração de funcionários";
            ViewData["Subtitle2"] = "Inserir novo";

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.InsertAsync(employee);
                return RedirectToAction(nameof(Index));
            }

            List<Section> sectors = await _sectorService.FindAllAsync();
            EmployeeViewModel viewModel = new() { Employee = employee, Sections = sectors };

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido." });

            Employee employee = await _employeeService.FindByIdAsync(id);
            if (employee == null)
                return RedirectToAction(nameof(Error), new { message = "Não foi possível encontrar um funcionário com o ID fornecido." });

            List<Section> sections = await _sectorService.FindAllAsync();
            EmployeeViewModel viewModel = new()
            {
                Sections = sections
            };

            ViewData["Title"] = "Administração de funcionários";
            ViewData["Subtitle2"] = "Editar funcionário";
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
                return RedirectToAction(nameof(Error), new { message = "O ID fornecido não corresponde ao ID do funcionário." });

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.UpdateAsync(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (ApplicationException error)
                {
                    return RedirectToAction(nameof(Error), new { message = error.Message });
                }
            }

            List<Section> sections = await _sectorService.FindAllAsync();
            EmployeeViewModel viewModel = new()
            {
                Sections = sections
            };

            ViewData["Title"] = "Administração de funcionários";
            ViewData["Subtitle2"] = "Editar funcionário";
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });

            Employee employee = await _employeeService.FindByIdAsync(id);
            if (employee == null)
                return RedirectToAction(nameof(Error), new { message = "Não foi possível encontrar um funcionário com o ID fornecido." });

            ViewData["Title"] = "Administração de funcionários";
            ViewData["Subtitle2"] = "Excluir funcionário: você tem certeza?";
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _employeeService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }
        }

        public IActionResult Error(string message)
        {
            string requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ErrorViewModel viewModel = new()
            {
                RequestId = requestId,
                Message = message
            };
            return View(viewModel);
        }
    }
}
