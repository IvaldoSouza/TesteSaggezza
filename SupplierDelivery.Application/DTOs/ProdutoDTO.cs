using SupplierDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierDelivery.Application.DTOs
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Nome é Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição é Obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal? Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string? Marca { get; set; }
        public string? CodigoBarras { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataInclusao { get; set; } = DateTime.UtcNow;
        public string UsuarioAtualizacao { get; set; } = null!;
        public string UsuarioInclusao { get; set; } = null!;
        public ICollection<EntregaEntity> Entregas { get; private set; } = new List<EntregaEntity>();
    }
}
