using SupplierDelivery.Domain.Validator;

namespace SupplierDelivery.Domain.Entities
{
    public sealed class ProdutoEntity
    {
        public ProdutoEntity()
        {
        }

        public ProdutoEntity(string nome, string? descricao, decimal? preco, int quantidadeEstoque, string marca, string codigoBarras,
            DateTime dataAtualizacao, DateTime dataInclusao, string usuarioAtualizacao, string usuarioInclusao)
        {
            ValidateDomain(nome, descricao, preco, quantidadeEstoque, marca, codigoBarras, dataAtualizacao, dataInclusao, usuarioAtualizacao, usuarioInclusao);
        }

        public ProdutoEntity(Guid id, string nome, string? descricao, decimal? preco, int quantidadeEstoque, string marca, string codigoBarras,
            DateTime dataAtualizacao, DateTime dataInclusao, string usuarioAtualizacao, string usuarioInclusao)
        {
            Id = id;
            ValidateDomain(nome, descricao, preco, quantidadeEstoque, marca, codigoBarras, dataAtualizacao, dataInclusao, usuarioAtualizacao, usuarioInclusao);
        }

        public void Update(string nome, string descricao, decimal preco, int quantidadeEstoque, string marca, string codigoBarras,
            DateTime dataAtualizacao, DateTime dataInclusao, string usuarioAtualizacao, string usuarioInclusao)
        {
            ValidateDomain(nome, descricao, preco, quantidadeEstoque, marca, codigoBarras, dataAtualizacao, dataInclusao, usuarioAtualizacao, usuarioInclusao);
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal? Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public string? Marca { get; private set; }
        public string? CodigoBarras { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public DateTime DataInclusao { get; private set; } = DateTime.UtcNow;
        public string UsuarioAtualizacao { get; private set; }
        public string UsuarioInclusao { get; private set; }
        public ICollection<EntregaEntity> Entregas { get; private set; } = new List<EntregaEntity>();

        private void ValidateDomain(string nome, string? descricao, decimal? preco, int quantidadeEstoque, string? marca, string? codigoBarras,
            DateTime dataAtualizacao, DateTime dataInclusao, string usuarioAtualizacao, string usuarioInclusao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido. Mínimo de 3 caracteres para nome do produto.");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            Marca = marca;
            CodigoBarras = codigoBarras;
            DataInclusao = dataInclusao;
            DataAtualizacao = dataAtualizacao;
            UsuarioInclusao = usuarioInclusao;
            UsuarioAtualizacao = usuarioAtualizacao;
        }

        public void BaixarEstoque(int quantidade)
        {
            QuantidadeEstoque -= quantidade;
        }
    }
}
