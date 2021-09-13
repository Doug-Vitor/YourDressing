using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class SalesController : Controller
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;

        public SalesController(ISaleRepository saleRepository, IEmployeeRepository employeeRepository,
            IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(int? page)
        {
            List<Sale> sales = await _saleRepository.GetAllAsync();

            return View(sales.ToPagedList(page ?? 1, 5));
        }

        public async Task<IActionResult> InitialInfos()
        {
            return View(new SelectList(await _employeeRepository.GetAllAsync(), "Id", "Name"));
        }

        [HttpPost]
        public IActionResult InitialInfos(int employeeId, int itemsQuantity)
        {
            return RedirectToAction(nameof(Create), new { employeeId, itemsQuantity });
        }

        public async Task<IActionResult> Create(int employeeId, int itemsQuantity)
        {
            Sale sale = new()
            {
                Employee = await _employeeRepository.FindByIdAsync(employeeId),
                EmployeeId = employeeId
            };
            for (int productsCount = 0; productsCount < itemsQuantity; productsCount++)
            {
                sale.OrderProducts.Add(null);
            }

            SelectList selectList = new(await _productRepository.FindBySectionAsync(sale.Employee.SectionId), 
                "Id", "Name");

            return View(new SaleInputViewModel(sale, itemsQuantity, selectList));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sale sale)
        {
            foreach (OrderProducts product in sale.OrderProducts)
            {
                product.Product = await _productRepository.FindByIdAsync(product.ProductId);
                product.Sale = sale;
            }

            if (ModelState.IsValid)
            {
                sale.SetTotalPrice();
                await _saleRepository.InsertAsync(sale);
                return RedirectToAction(nameof(Index));
            }

            int itemsQuantity = sale.OrderProducts.Count;
            SelectList selectList = new(await _productRepository.FindBySectionAsync(sale.Employee.SectionId));

            SaleInputViewModel viewModel = new(sale, itemsQuantity, selectList);
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                Sale sale = await _saleRepository.FindByIdAsync(id);
                return View(sale);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                Sale sale = await _saleRepository.FindByIdAsync(id);
                return View(sale);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                Sale sale = await _saleRepository.FindByIdAsync(id);
                return View(sale);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _saleRepository.RemoveAsync(id);
            }
            catch (ApplicationException error)
            {
                return RedirectToAction(nameof(Error), new { message = error.Message });
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {
            string requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View(new ErrorViewModel(requestId, message));
        }
    }
}