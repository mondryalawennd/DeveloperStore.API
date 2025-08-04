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
    public class FilialConfiguration : IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> builder)
        {
            builder.ToTable("Filial");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                  .ValueGeneratedOnAdd();

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
