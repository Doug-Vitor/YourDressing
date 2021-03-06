using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDressing.DataContext;
using YourDressing.Models;
using YourDressing.Models.Enums;
using YourDressing.Repositories.Exceptions;
using YourDressing.Repositories.Interfaces;

namespace YourDressing.Repositories
{
    internal class SectionRepository : ISectionRepository
    {
        private readonly AppDbContext _context;

        public SectionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Section section)
        {
            await _context.Sections.AddAsync(section);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Section>> GetAllAsync()
        {
            return await _context.Sections.Where(prop => prop.Situation == SectionSituation.Active)
                .OrderBy(prop => prop.Name).ToListAsync();
        }

        public async Task<List<Section>> GetDisabledSectionsAsync()
        {
            return await _context.Sections.Where(prop => prop.Situation == SectionSituation.Disabled)
                .OrderBy(prop => prop.Name).ToListAsync();
        }

        public async Task<Section> FindByIdAsync(int? id)
        {
            if (id is null)
                throw new IdNotProvidedException("ID não fornecido.");

            Section section = await _context.Sections.Include(prop => prop.Employees).ThenInclude(prop => prop.Sales)
                .Where(prop => prop.Id == id).FirstOrDefaultAsync();
            if (section is null)
                throw new NotFoundException("Não foi possível encontrar uma seção correspondente ao ID fornecido.");

            return section;
        }

        public async Task<List<Employee>> GetSectionEmployeesAsync(int id)
        {
            return await _context.Employees.Where(prop => prop.SectionId == id).ToListAsync();
        }

        public async Task<List<Sale>> GetSectionSalesAsync(int id)
        {
            return await _context.Sales.Where(prop => prop.Employee.SectionId == id).ToListAsync();
        }

        public async Task UpdateAsync(Section section)
        {
            _context.Update(section);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            Section section = await FindByIdAsync(id);
            if (section.Employees.Count == 0 && section.Products.Count == 0)
            {
                _context.Remove(section);
                await _context.SaveChangesAsync();
            }
            else
            {
                section.Situation = SectionSituation.Disabled;
                await UpdateAsync(section);
            }
        }
    }
}