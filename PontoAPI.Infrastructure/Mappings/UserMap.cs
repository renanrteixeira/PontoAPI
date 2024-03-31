using Microsoft.EntityFrameworkCore;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Mappings
{
       public class UserMap : IEntityTypeConfiguration<User>
       {
              public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
              {
                     builder.ToTable("users");

                     builder.HasKey(p => p.Id);

                     builder.Property(p => p.Id)
                            .HasColumnName("id")
                            .IsRequired()
                            .HasColumnType("varchar")
                            .HasMaxLength(100);
                     builder.Property(p => p.Name)
                            .HasColumnName("name")
                            .IsRequired()
                            .HasColumnType("varchar")
                            .HasMaxLength(50);
                     builder.Property(p => p.Email)
                            .HasColumnName("email")
                            .IsRequired()
                            .HasColumnType("varchar")
                            .HasMaxLength(250);
                     builder.Property(p => p.UserName)
                            .HasColumnName("username")
                            .IsRequired()
                            .HasColumnType("varchar")
                            .HasMaxLength(255);
                     builder.Property(p => p.Password)
                            .HasColumnName("password")
                            .IsRequired()
                            .HasColumnType("varchar")
                            .HasMaxLength(255);
                     builder.Property(p => p.Admin)
                            .HasColumnName("admin")
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