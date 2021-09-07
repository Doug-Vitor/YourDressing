using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using YourDressing.Models;
using YourDressing.Models.ViewModels;
using YourDressing.Repositories.Interfaces;

namespace YourDressing.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionController(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _sectionRepository.GetAllAsync());
        }
        
        public async Task<IActionResult> Disabled()
        {
            return View(await _sectionRepository.GetDisabledSectionsAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Section section)
        {
            if (ModelState.IsValid)
            {
                await _sectionRepository.InsertAsync(section);
                return RedirectToAction(nameof(Index));
            }

            return View(section);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Section section = new();
            try
            {
                section = await _sectionRepository.FindByIdAsync(id);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }

            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Section section)
        {
            if (ModelState.IsValid)
            {
                await _sectionRepository.UpdateAsync(section);
                return RedirectToAction(nameof(Index));
            }

            return View(section);
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(await _sectionRepository.FindByIdAsync(id));
        }

        public async Task<IActionResult> SectionEmployees(int id, int? page)
        {
            List<Employee> employees = await _sectionRepository.GetSectionEmployees(id);

            Section _ = await _sectionRepository.FindByIdAsync(id);
            ViewBag.SectionName = _.Name.ToLower();

            return View(await employees.ToPagedListAsync(page ?? 1, 5));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Section section = new();
            try
            {
                section = await _sectionRepository.FindByIdAsync(id);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }

            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Section section)
        {
            await _sectionRepository.RemoveAsync(section);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            string requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View(new ErrorViewModel(requestId, message));
        }
    }
}
