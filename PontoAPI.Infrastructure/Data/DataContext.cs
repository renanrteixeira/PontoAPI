using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Company> companies { get; set; }
        public DbSet<Employe> employees { get; set; }
        public DbSet<Hour> hours { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<TypeDate> typedates { get; set; }
        public DbSet<User> users { get; set; }
    }

}
