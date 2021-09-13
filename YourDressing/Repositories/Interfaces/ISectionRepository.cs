using System.Collections.Generic;
using System.Threading.Tasks;
using YourDressing.Models;

namespace YourDressing.Repositories.Interfaces
{
    public interface ISectionRepository
    {
        public Task InsertAsync(Section section);
        public Task<List<Section>> GetAllAsync();
        public Task<List<Section>> GetDisabledSectionsAsync();
        public Task<Section> FindByIdAsync(int? id);
        public Task<List<Employee>> GetSectionEmployeesAsync(int id);
        public Task<List<Sale>> GetSectionSalesAsync(int id);
        public Task UpdateAsync(Section section);
        public Task RemoveAsync(Section section);
    }
}
