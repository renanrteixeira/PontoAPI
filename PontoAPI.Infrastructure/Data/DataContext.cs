using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connection = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
            }
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
