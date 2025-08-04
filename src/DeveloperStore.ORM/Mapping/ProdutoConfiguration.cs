using DeveloperStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.ORM.Mapping
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Descricao)
                   .HasMaxLength(250);

            builder.Property(p => p.Preco)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
        }
    }
}