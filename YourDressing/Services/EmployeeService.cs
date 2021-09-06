using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDressing.DataContext;
using YourDressing.Models;
using YourDressing.Models.Enums;
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

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.Include(prop => prop.Section)
                .Where(prop => prop.Situation == Situation.Active).OrderBy(x => x.Section.Name)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetMonthEmployeesAsync()
        {
            return await _context.Employees.Include(prop => prop.Section)
                .Where(prop => prop.IsMonthEmployee).OrderBy(x => x.Section.Name).ToListAsync();
        }

        public async Task<Employee> FindByIdAsync(int? id)
        {
            if (id == null)
                throw new IdNotProvidedException("ID não fornecido");

            Employee employee = await _context.Employees.Include(prop => prop.Section).Where(prop => prop.Id == id)
                .FirstOrDefaultAsync();
            if (employee == null)
                throw new NotFoundException("Não foi possível encontrar um funcionário com o ID fornecido.");

            return employee;
        }

        public async Task<List<Employee>> FindByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return await GetAllAsync();

            name = name.ToLower();
            return await _context.Employees.Include(prop => prop.Section)
                .Where(prop => prop.Name.ToLower().Contains(name)).OrderBy(x => x.Section.Name)
                .ToListAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            Employee employee = await FindByIdAsync(id);
            employee.Situation = Situation.Fired;
            employee.IsMonthEmployee = false;

            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
