using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using X.PagedList;
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

        public async Task<IActionResult> Index(string filter, string searchString, int? page)
        {
            if (filter is null)
               filter = "All";

            return View
            (
                await EmployeeViewModel.DefineFieldsAndReturnViewModel(filter,  searchString, 
                page, await _employeeService.GetAllAsync())
            );
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Title"] = "Administração de funcionários";
            ViewBag.Subtitle2 = "Inserir novo";

            return View(new CreateEmployeeViewModel(await _sectorService.GetAllAsync()));
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

            return View(new CreateEmployeeViewModel(employee, await _sectorService.GetAllAsync()));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Employee employee = new();
            try
            {
                employee = await _employeeService.FindByIdAsync(id);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error });
            }

            ViewData["Title"] = "Administração de funcionários";
            ViewBag.Subtitle2 = "Editar funcionário";
            return View(new CreateEmployeeViewModel(employee, await _sectorService.GetAllAsync()));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
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

            ViewData["Title"] = "Administração de funcionários";
            ViewBag.Subtitle2 = "Editar funcionário";
            return View(new CreateEmployeeViewModel(await _sectorService.GetAllAsync()));
        }

        public async Task<IActionResult> Details(int? id)
        {
            Employee employee = new();
            try
            {
                employee = await _employeeService.FindByIdAsync(id);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error });
            }


            ViewData["Title"] = "Administração de funcionários";
            ViewBag.Subtitle2 = "Detalhes do funcionário";
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Employee employee = new();
            try
            {
                employee = await _employeeService.FindByIdAsync(id);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error });
            }

            ViewData["Title"] = "Administração de funcionários";
            ViewBag.Subtitle2 = "Excluir funcionário: você tem certeza?";
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
            return View(new ErrorViewModel(requestId,  message));
        }
    }
}
