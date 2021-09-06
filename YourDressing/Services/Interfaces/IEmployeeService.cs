using System.Collections.Generic;
using System.Threading.Tasks;
using YourDressing.Models;
using YourDressing.Models.ViewModels;

namespace YourDressing.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task InsertAsync(Employee employee);
        public Task<List<Employee>> GetAllAsync();
        public Task<List<Employee>> GetMonthEmployeesAsync();
        public Task<List<Employee>> FindByNameAsync(string name);
        public Task<Employee> FindByIdAsync(int? id);
        public Task UpdateAsync(Employee employee);
        public Task RemoveAsync(int id);
    }
}
