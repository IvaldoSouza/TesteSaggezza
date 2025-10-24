using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierDelivery.Domain.Entities;

namespace SupplierDelivery.Infra.Data.EntitiesConfiguration
{
    public class EntregaConfigutation : IEntityTypeConfiguration<EntregaEntity>
    {
        public void Configure(EntityTypeBuilder<EntregaEntity> builder)
        {
            builder.HasOne(e => e.Fornecedor)
               .WithMany(f => f.Entregas)
               .HasForeignKey(e => e.FornecedorId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Produto)
                .WithMany(p => p.Entregas)
                .HasForeignKey(e => e.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
