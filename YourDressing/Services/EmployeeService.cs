using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDressing.DataContext;
using YourDressing.Models;
using YourDressing.Services.Exceptions;
using YourDressing.Services.Interfaces;

namespace YourDressing.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Employee employee)
        {
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> FindAllAsync()
        {
            return await _context.Employees.Include(prop => prop.Section).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<Employee>> FindByCategoryAsync(string sector)
        {
            if (string.IsNullOrWhiteSpace(sector))
                return await _context.Employees.OrderBy(x => x.Name).ToListAsync();

            return await _context.Employees.Where(prop => prop.Section.Equals(sector))
                .OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Employee> FindByIdAsync(int? id)
        {
            return await _context.Employees.Include(prop => prop.Section)
                .Where(prop => prop.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> FindByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await _context.Employees.Include(prop => prop.Section).OrderBy(x => x.Name)
                    .ToListAsync();

            return await _context.Employees.Include(prop => prop.Section).Where(prop => prop.Section
            .Equals(name)).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<List<Employee>> GetMonthEmployeesAsync()
        {
            return await _context.Employees.Include(prop => prop.Section).Where(prop => prop.IsMonthEmployee)
                .OrderBy(x => x.Name).ToListAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            Employee employee = await FindByIdAsync(id);

            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Este funcionário possui vendas atreladas a ele. Não é possível deletá-lo.");
            }
        }
    }
}
