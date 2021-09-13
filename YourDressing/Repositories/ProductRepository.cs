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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task InsertAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(prop => prop.Section).OrderBy(prop => prop.Section.Name)
                .ThenByDescending(prop => prop.Price).ToListAsync();
        }

        public async Task<List<Product>> FindByNameAsync(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return await GetAllAsync();

            string name = searchString.ToLower();
            return await _context.Products.Include(prop => prop.Section)
                .Where(prop => prop.Name.ToLower().Contains(name)).OrderBy(prop => prop.Section.Name).ToListAsync();
        }

        public async Task<List<Product>> FindBySectionAsync(int sectionId)
        {
            return await _context.Products.Where(prop => prop.SectionId == sectionId).ToListAsync();
        }

        public async Task<Product> FindByIdAsync(int? id)
        {
            if (id is null)
                throw new IdNotProvidedException("ID não fornecido.");

            Product product = await _context.Products.Where(prop => prop.Id == id).Include(prop => prop.Section)
                .FirstOrDefaultAsync();
            if (product is null)
                throw new NotFoundException("Não foi possível encontrar um produto correspondente ao ID fornecido.");

            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
