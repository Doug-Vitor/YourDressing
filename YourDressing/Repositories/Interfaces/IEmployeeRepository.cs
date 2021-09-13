using System.Collections.Generic;
using System.Threading.Tasks;
using YourDressing.Models;

namespace YourDressing.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task InsertAsync(Employee employee);
        public Task<List<Employee>> GetAllAsync();
        public Task<List<Employee>> GetMonthEmployeesAsync();
        public Task<List<Employee>> GetFiredEmployeesAsync();
        public Task<List<Employee>> FindByNameAsync(string name);
        public Task<Employee> FindByIdAsync(int? id);
        public Task<List<Sale>> GetEmployeeSalesAsync(int id);
        public Task UpdateAsync(Employee employee);
        public Task RemoveAsync(Employee employee);
    }
}
