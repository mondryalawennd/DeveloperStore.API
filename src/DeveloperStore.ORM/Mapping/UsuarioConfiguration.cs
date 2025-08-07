using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DeveloperStore.Domain.Entities;

namespace DeveloperStore.ORM.Mapping
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(u => u.Nome).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

            builder.Property(u => u.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(u => u.Papel)
                .HasConversion<string>()
                .HasMaxLength(20);

        }
    }
}