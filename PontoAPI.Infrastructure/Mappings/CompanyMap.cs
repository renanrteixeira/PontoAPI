using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Mappings
{
       public class CompanyMap : IEntityTypeConfiguration<Company>
       {
              public void Configure(EntityTypeBuilder<Company> builder)
              {
                     builder.ToTable("companies");

                     builder.HasKey(p => p.Id);

                     builder.HasMany(p => p.Employees)
                            .WithOne(p => p.Company)
                            .HasForeignKey(p => p.CompanyId)
                            .IsRequired();

                     builder.Property(p => p.Id)
                            .HasColumnName("id")
                            .IsRequired()
                            .HasColumnType("varchar")
                            .HasMaxLength(100);
                     builder.Property(p => p.Name)
                            .HasColumnName("name")
                            .IsRequired()
                            .HasColumnType("varchar")
                            .HasMaxLength(250);
                     builder.Property(p => p.Address)
                            .HasColumnName("address")
                            .IsRequired()
                            .HasColumnType("varchar")
                            .HasMaxLength(250);
                     builder.Property(p => p.Telephone)
                            .HasColumnName("telephone")
                            .IsRequired()
                            .HasColumnType("varchar")
                            .HasMaxLength(15);
              }
       }
}