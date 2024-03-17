using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;
using PontoAPI.Infrastructure.Mappings;

namespace PontoAPI.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Hour> Hours { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TypeDate> Typedates { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new TypeDateMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new HourMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }

}
