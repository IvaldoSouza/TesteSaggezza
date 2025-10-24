using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierDelivery.Domain.Entities;

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

            builder.HasData(
                new ProdutoEntity(
                    id: Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"),
                    nome: "Produto Exemplo 1",
                    descricao: "Descrição do Produto Exemplo 1",
                    preco: 19.99m,
                    quantidadeEstoque: 100,
                    marca: "Marca A",
                    codigoBarras: "1234567890123",
                    dataAtualizacao: DateTime.UtcNow,
                    dataInclusao: DateTime.UtcNow,
                    usuarioAtualizacao: "admin",
                    usuarioInclusao: "admin"
                ),
                new ProdutoEntity(
                    id: Guid.Parse("e13b5f4e-7c54-4b01-90e6-d701748f0852"),
                    nome: "Produto Exemplo 2",
                    descricao: "Descrição do Produto Exemplo 2",
                    preco: 29.99m,
                    quantidadeEstoque: 50,
                    marca: "Marca B",
                    codigoBarras: "9876543210987",
                    dataAtualizacao: DateTime.UtcNow,
                    dataInclusao: DateTime.UtcNow,
                    usuarioAtualizacao: "admin",
                    usuarioInclusao: "admin"
                )
            );
        }
    }
}
