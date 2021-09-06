using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourDressing.DataContext;
using YourDressing.Models;
using YourDressing.Services.Interfaces;

namespace YourDressing
{
    internal class SectionService : ISectionService
    {
        private readonly AppDbContext _context;

        public SectionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Section>> GetAllAsync()
        {
            return await _context.Sections.ToListAsync();
        }
    }
}