using SupplierDelivery.Domain.Validator;
using System.Text.RegularExpressions;

namespace SupplierDelivery.Domain.Entities
{
    public sealed class FornecedorEntity
    {
        private FornecedorEntity() { }

        public FornecedorEntity(string razaoSocial, string nomeFantasia, string cnpj, string telefone, string email, string endereco)
        {
            if (string.IsNullOrWhiteSpace(razaoSocial))
                throw new ArgumentException("A razão social é obrigatória.");

            if (string.IsNullOrWhiteSpace(cnpj))
                throw new ArgumentException("O CNPJ é obrigatório.");

            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public bool Ativo { get; private set; }
        public string UsuarioAtualizacao { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public string UsuarioInclusao { get; private set; }
        public DateTime DataInclusao { get; private set; } = DateTime.UtcNow;
        public ICollection<EntregaEntity> Entregas { get; private set; } = new List<EntregaEntity>();

        private void ValidateDomain(string razaoSocial, string nomeFantasia, string cnpj, string telefone, string email, string endereco,
            DateTime dataAtualizacao, DateTime dataInclusao, string usuarioAtualizacao, string usuarioInclusao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(razaoSocial), "Razao Social inválido. Razao Social é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeFantasia), "Nome inválido. Nome é obrigatório.");
            DomainExceptionValidation.When(nomeFantasia.Length < 3, "Nome inválido. Mínimo de 3 caracteres para nome da Razao Social.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cnpj), "CNPJ inválido. CNPJ é obrigatório.");
            DomainExceptionValidation.When(!Regex.IsMatch(cnpj, @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$"), "CNPJ inválido. Formato esperado: 00.000.000/0000-00.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Telefone inválido. Telefone é obrigatório.");

            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            DataInclusao = dataInclusao;
            DataAtualizacao = dataAtualizacao;
            UsuarioInclusao = usuarioInclusao;
            UsuarioAtualizacao = usuarioAtualizacao;
        }
    }
}
