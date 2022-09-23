using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Data
{
    public class CompanyContext : DataContext

    {
        public CompanyContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Company> companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var company = modelBuilder.Entity<Company>();
            company.ToTable("companies");
            company.HasKey(x => x.Id);
            company.Property(x => x.Id).HasColumnName("id").IsRequired().HasColumnType("bigint");
            company.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50).HasColumnType("varchar");
            company.Property(x => x.Address).HasColumnName("address").IsRequired().HasMaxLength(500).HasColumnType("varchar");
            company.Property(x => x.Telephone).HasColumnName("telephone").IsRequired().HasMaxLength(50).HasColumnType("varchar");
        }
    }

}