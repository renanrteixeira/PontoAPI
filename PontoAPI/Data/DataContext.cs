using Microsoft.EntityFrameworkCore;
using PontoAPI.Models;

namespace PontoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
    }
}
