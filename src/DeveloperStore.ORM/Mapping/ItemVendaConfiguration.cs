using DeveloperStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperStore.ORM.Mapping
{
    public class ItemVendaConfiguration : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("ItensVenda");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.ProdutoId)
                .IsRequired();

            builder.Property(i => i.Quantidade)
                .IsRequired();

            builder.Property(i => i.PrecoUnitario)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.Desconto)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.ValorTotal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.Cancelado)
                .IsRequired();

            builder.Property(i => i.VendaId)
                .IsRequired();

            builder.HasOne(i => i.Produto)
                .WithMany()
                .HasForeignKey(i => i.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Venda)
                .WithMany(v => v.Itens)
                .HasForeignKey(i => i.VendaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
