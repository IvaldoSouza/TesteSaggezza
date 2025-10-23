using Microsoft.EntityFrameworkCore;
using SupplierDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierDelivery.Infra.Data.EntitiesConfiguration
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<FornecedorEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FornecedorEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Cnpj).HasMaxLength(14).IsRequired();
            builder.Property(p => p.RazaoSocial).HasMaxLength(200).IsRequired();
            builder.Property(p => p.NomeFantasia).HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.UsuarioInclusao).HasMaxLength(100).IsRequired();
            builder.Property(p => p.UsuarioAtualizacao).HasMaxLength(100).IsRequired();
        }
    }
}
