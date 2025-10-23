using SupplierDelivery.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SupplierDelivery.Application.DTOs
{
    public class FornecedorDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Razão Social é Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Nome Fantasia é Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "CNPJ é Obrigatório")]
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public bool Ativo { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string UsuarioInclusao { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.UtcNow;
        public ICollection<EntregaEntity> Entregas { get; set; } = new List<EntregaEntity>();
    }
}
