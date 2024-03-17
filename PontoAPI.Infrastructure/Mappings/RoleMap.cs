using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Employees)
                   .WithOne(b => b.Role)
                   .HasForeignKey(p => p.RoleId);

            builder.Property(p => p.Id)
                   .HasColumnName("id")
                   .IsRequired()
                   .HasColumnType("int")
                   .ValueGeneratedOnAdd();
            builder.Property(p => p.Name)
                   .HasColumnName("name")
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasMaxLength(50);
        }
    }
}