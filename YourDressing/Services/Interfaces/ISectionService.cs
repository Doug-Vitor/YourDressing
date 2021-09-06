using System.Collections.Generic;
using System.Threading.Tasks;
using YourDressing.Models;

namespace YourDressing.Services.Interfaces
{
    public interface ISectionService
    {
        public Task<List<Section>> GetAllAsync();
    }
}
