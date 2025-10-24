using SupplierDelivery.Domain.Entities;

namespace SupplierDelivery.Application.DTOs
{
    public class EntregaDTO
    {
        public Guid FornecedorId { get; set; }
        public Guid ProdutoId { get; set; }
        public DateTime DataEntrega { get; set; }
        public int Quantidade { get; set; }
    }
}
