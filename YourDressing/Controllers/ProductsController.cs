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
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ISectionRepository _sectionRepository;

        public ProductsController(IProductRepository productRepository, ISectionRepository sectionRepository)
        {
            _productRepository = productRepository;
            _sectionRepository = sectionRepository;
        }

        public async Task<IActionResult> Index(int? page, string searchString)
        {
            List<Product> products;
            if (string.IsNullOrWhiteSpace(searchString))
                products = await _productRepository.GetAllAsync();
            else
            {
                products = await _productRepository.FindByNameAsync(searchString);
                ViewBag.SearchString = searchString;
            }

            return View(products.ToPagedList(page ?? 1, 9));
        }

        public async Task<IActionResult> Create()
        {
            return View(new ProductInputViewModel(await _sectionRepository.GetAllAsync()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.InsertAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(new ProductInputViewModel(product, await _sectionRepository.GetAllAsync()));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                Product product = await _productRepository.FindByIdAsync(id);
                return View(new ProductInputViewModel(product, await _sectionRepository.GetAllAsync()));
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                Product product = await _productRepository.FindByIdAsync(id.Value);
                return View(product);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Product product)
        {
            await _productRepository.RemoveAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            string requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View(new ErrorViewModel(requestId, message));
        }
    }
}