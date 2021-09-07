using Microsoft.EntityFrameworkCore;
using YourDressing.Models;
using YourDressing.Models.Enums;

namespace YourDressing.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(employee => {
                employee.Property(prop => prop.Situation).HasDefaultValue(EmployeeSituation.Active);
                employee.Property(prop => prop.IsMonthEmployee).HasDefaultValue(false);
                employee.Property(prop => prop.BaseSalary).HasDefaultValue(1299);
            });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
