using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Mappings
{
    public class TypeDateMap : IEntityTypeConfiguration<TypeDate>
    {
        public void Configure(EntityTypeBuilder<TypeDate> builder)
        {
            builder.ToTable("typedates");

            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Hours)
                   .WithOne(p => p.TypeDate)
                   .HasForeignKey(p => p.TypeDateId)
                   .IsRequired();
            
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
            builder.Property(p => p.Time)
                   .HasColumnName("time")
                   .IsRequired()
                   .HasColumnType("time");
            builder.Property(p => p.Weekend)
                   .HasColumnName("weekend")
                   .IsRequired()
                   .HasColumnType("char")
                   .HasMaxLength(1);
        }
    }
}