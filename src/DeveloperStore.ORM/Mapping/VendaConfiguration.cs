using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DeveloperStore.Domain.Entities;

namespace DeveloperStore.ORM.Mapping
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Vendas");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(v => v.NumeroVenda)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(v => v.DataVenda)
                   .IsRequired();

            builder.Property(v => v.Cancelado)
                   .IsRequired();

            // Configura relacionamento com Cliente (1:N)
            builder.HasOne(v => v.Cliente)
                   .WithMany()
                   .HasForeignKey(v => v.ClienteId)  // Usando ClienteId como chave estrangeira
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(v => v.ValorTotal)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            // Configura relacionamento com Filial (1:N)
            builder.HasOne(v => v.Filial)
                   .WithMany()
                   .HasForeignKey(v => v.FilialId)  // Usando FilialId como chave estrangeira
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento 1:N Venda -> ItensVenda
            builder.HasMany(v => v.Itens)
                   .WithOne(i => i.Venda)
                   .HasForeignKey(i => i.VendaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}