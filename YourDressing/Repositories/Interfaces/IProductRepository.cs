using System.Collections.Generic;
using System.Threading.Tasks;
using YourDressing.Models;

namespace YourDressing.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task InsertAsync(Product product);
        public Task<List<Product>> GetAllAsync();
        public Task<List<Product>> FindByNameAsync(string searchString);
        public Task<List<Product>> FindBySectionAsync(int sectionId);
        public Task<Product> FindByIdAsync(int? id);
        public Task UpdateAsync(Product product);
        public Task RemoveAsync(Product product);
    }
}
