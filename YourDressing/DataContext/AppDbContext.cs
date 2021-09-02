using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using YourDressing.Models;

namespace YourDressing.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
