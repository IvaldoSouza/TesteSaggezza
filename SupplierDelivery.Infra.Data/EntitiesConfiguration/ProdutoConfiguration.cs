using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierDelivery.Infra.Data.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CodigoBarras).HasMaxLength(100).IsRequired(false);
            builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.Marca).HasMaxLength(100).IsRequired(false);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Preco).HasPrecision(10, 2);
            builder.Property(p => p.UsuarioInclusao).HasMaxLength(100).IsRequired();
            builder.Property(p => p.UsuarioAtualizacao).HasMaxLength(100).IsRequired();
        }
    }
}
