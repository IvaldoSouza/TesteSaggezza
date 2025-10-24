namespace SupplierDelivery.Application.DTOs
{
    public class EntregaQueryDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FornecedorId { get; set; }
        public Guid ProdutoId { get; set; }
        public DateTime DataEntrega { get; set; }
        public int Quantidade { get; set; }
        public FornecedorQueryDTO Fornecedor { get; set; }
        public ProdutoQueryDTO Produto { get; set; }
    }
}
