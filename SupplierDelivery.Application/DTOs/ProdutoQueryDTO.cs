namespace SupplierDelivery.Application.DTOs
{
    public class ProdutoQueryDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string? Marca { get; set; }
        public string? CodigoBarras { get; set; }
    }
}
