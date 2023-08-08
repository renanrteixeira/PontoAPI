using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;

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
    }

}
