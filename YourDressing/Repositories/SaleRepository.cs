using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDressing.DataContext;
using YourDressing.Models;
using YourDressing.Repositories.Exceptions;
using YourDressing.Repositories.Interfaces;

namespace YourDressing.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _context;

        public SaleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Sale sale)
        {
            foreach (OrderProducts product in sale.OrderProducts)
            {
                product.Product = await _context.Products.Where(prop => prop.Id == product.ProductId)
                    .FirstOrDefaultAsync();
                product.Sale = sale;
            }

            sale.SetTotalPrice();
            _context.Add(sale);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await _context.Sales.Include(prop => prop.Employee).ToListAsync();
        }

        public async Task<Sale> FindByIdAsync(int? id)
        {
            if (id is null)
                throw new IdNotProvidedException("ID não fornecido");

            Sale sale = await _context.Sales.Where(prop => prop.Id == id).Include(prop => prop.OrderProducts)
                .ThenInclude(prop => prop.Product).Include(prop => prop.Employee).FirstOrDefaultAsync();
            if (sale is null)
                throw new NotFoundException("Não foi possível encontrar uma venda correspondente ao ID fornecido.");

            return sale;
        }

        public async Task UpdateAsync(Sale sale)
        {
            _context.Update(sale);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Sale sale = await FindByIdAsync(id);

                _context.Remove(sale);
                await _context.SaveChangesAsync();
            }
            catch (ApplicationException error)
            {
                throw new ApplicationException(error.Message);
            }
        }
    }
}
