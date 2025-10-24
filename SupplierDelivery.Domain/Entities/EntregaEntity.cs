namespace SupplierDelivery.Domain.Entities
{
    public sealed class EntregaEntity
    {
        private EntregaEntity() { }

        public EntregaEntity(Guid fornecedorId, Guid produtoId, DateTime dataEntrega, int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            FornecedorId = fornecedorId;
            ProdutoId = produtoId;
            DataEntrega = dataEntrega;
            Quantidade = quantidade;
        }
        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid FornecedorId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public int Quantidade { get; private set; }
        public FornecedorEntity Fornecedor { get; private set; }
        public ProdutoEntity Produto { get; private set; }
    }
}
