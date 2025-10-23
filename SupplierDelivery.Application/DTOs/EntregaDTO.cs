using SupplierDelivery.Domain.Entities;

namespace SupplierDelivery.Application.DTOs
{
    public class EntregaDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid FornecedorId { get; set; }
        public Guid ProdutoId { get; set; }
        public DateTime DataEntrega { get; set; }
        public int Quantidade { get; set; }
        public FornecedorEntity Fornecedor { get; set; }
        public ProdutoEntity Produto { get; set; }
    }
}
