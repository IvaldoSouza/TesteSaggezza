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
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string? Marca { get; set; }
        public string? CodigoBarras { get; set; }
    }
}
