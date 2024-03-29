using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Mappings
{
       public class EmployeeMap : IEntityTypeConfiguration<Employee>
       {
              public void Configure(EntityTypeBuilder<Employee> builder)
              {
                     builder.ToTable("employees");

                     builder.HasKey(p => p.Id);

                     builder.HasOne(p => p.Role)
                            .WithMany(p => p.Employees)
                            .HasForeignKey(p => p.RoleId)
                            .IsRequired();

                     builder.HasOne(p => p.Company)
                            .WithMany(p => p.Employees)
                            .HasForeignKey(p => p.CompanyId)
                            .IsRequired();

                     builder.HasMany(p => p.Hours)
                            .WithOne(p => p.Employee)
                            .HasForeignKey(p => p.Id)
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
                     builder.Property(p => p.Admission)
                            .HasColumnName("admission")
                            .IsRequired()
                            .HasColumnType("date");
                     builder.Property(p => p.Gender)
                            .HasColumnName("gender")
                            .IsRequired()
                            .HasColumnType("char")
                            .HasMaxLength(1);
                     builder.Property(p => p.Status)
                            .HasColumnName("status")
                            .IsRequired()
                            .HasColumnType("char")
                            .HasMaxLength(1);
              }
       }
}