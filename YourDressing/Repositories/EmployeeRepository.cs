using Microsoft.EntityFrameworkCore;
using System;
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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
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
                .Where(prop => prop.Situation == EmployeeSituation.Active).OrderBy(x => x.Section.Name)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetMonthEmployeesAsync()
        {
            return await _context.Employees.Include(prop => prop.Section)
                .Where(prop => prop.IsMonthEmployee).OrderBy(x => x.Section.Name).ToListAsync();
        }

        public async Task<List<Employee>> GetFiredEmployeesAsync()
        {
            return await _context.Employees.Include(prop => prop.Section)
                .Where(prop => prop.Situation == EmployeeSituation.Fired)
                .OrderBy(prop => prop.Section.Name).ToListAsync();
        }

        public async Task<Employee> FindByIdAsync(int? id)
        {
            if (id is null)
                throw new IdNotProvidedException("ID não fornecido");

            Employee employee = await _context.Employees.Where(prop => prop.Id == id).Include(prop => prop.Section)
                .FirstOrDefaultAsync();
            if (employee is null)
                throw new NotFoundException("Não foi possível encontrar um funcionário correspondente ao ID fornecido.");

            return employee;
        }

        public async Task<List<Sale>> GetEmployeeSalesAsync(int id)
        {
            return await _context.Sales.Where(prop => prop.EmployeeId == id).ToListAsync();
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

        public async Task RemoveAsync(Employee employee)
        {
            employee.Situation = EmployeeSituation.Fired;
            employee.IsMonthEmployee = false;
            employee.BaseSalary = 0.0;

            await UpdateAsync(employee);
        }
    }
}
