using System.Collections.Generic;
using System.Threading.Tasks;
using YourDressing.Models;

namespace YourDressing.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        public Task InsertAsync(Sale sale);
        public Task<List<Sale>> GetAllAsync();
        public Task<Sale> FindByIdAsync(int? id);
        public Task UpdateAsync(Sale sale);
        public Task RemoveAsync(int id);
    }
}
