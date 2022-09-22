using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
    }
}
