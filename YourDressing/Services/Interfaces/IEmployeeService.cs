using System.Collections.Generic;
using System.Threading.Tasks;
using YourDressing.Models;

namespace YourDressing.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task InsertAsync(Employee employee);
        public Task<List<Employee>> FindAllAsync();
        public Task<List<Employee>> FindByNameAsync(string name);
        public Task<List<Employee>> FindByCategoryAsync(string sector);
        public Task<Employee> FindByIdAsync(int? id);
        public Task<List<Employee>> GetMonthEmployeesAsync();
        public Task UpdateAsync(Employee employee);
        public Task RemoveAsync(int id);
    }
}
