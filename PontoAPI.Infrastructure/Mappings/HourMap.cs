using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Mappings
{
       public class HourMap : IEntityTypeConfiguration<Hour>
       {
              public void Configure(EntityTypeBuilder<Hour> builder)
              {
                     builder.ToTable("hours");

                     builder.HasKey(p => p.Id);

                     builder.HasOne(p => p.Employee)
                            .WithMany(p => p.Hours)
                            .HasForeignKey(p => p.EmployeeId);

                     builder.HasOne(p => p.TypeDate)
                            .WithMany(p => p.Hours)
                            .HasForeignKey(p => p.TypeDateId);

                     builder.Property(p => p.Id)
                            .HasColumnName("id")
                            .IsRequired()
                            .HasColumnType("varchar")
                            .HasMaxLength(100);
                     builder.Property(p => p.EmployeeId)
                             .HasColumnName("employeeId")
                             .IsRequired()
                             .HasColumnType("int");
                     builder.Property(p => p.Date)
                            .HasColumnName("date")
                            .IsRequired()
                            .HasColumnType("date");
                     builder.Property(p => p.Type)
                            .HasColumnName("type")
                            .IsRequired()
                            .HasColumnType("int");
                     builder.Property(p => p.TypeDateId)
                             .HasColumnName("typeDateId")
                             .IsRequired()
                             .HasColumnType("int");
                     builder.Property(p => p.Hour1)
                            .HasColumnName("hour1")
                            .IsRequired()
                            .HasColumnType("time");
                     builder.Property(p => p.Hour2)
                            .HasColumnName("hour2")
                            .IsRequired()
                            .HasColumnType("time");
                     builder.Property(p => p.Hour3)
                            .HasColumnName("hour3")
                            .IsRequired()
                            .HasColumnType("time");
                     builder.Property(p => p.Hour4)
                            .HasColumnName("hour4")
                            .IsRequired()
                            .HasColumnType("time");
                     builder.Property(p => p.Hour5)
                            .HasColumnName("hour5")
                            .IsRequired()
                            .HasColumnType("time");
                     builder.Property(p => p.Hour6)
                            .HasColumnName("hour6")
                            .IsRequired()
                            .HasColumnType("time");
                     builder.Property(p => p.Balance)
                            .HasColumnName("balance")
                            .IsRequired()
                            .HasColumnType("time");
              }
       }
}