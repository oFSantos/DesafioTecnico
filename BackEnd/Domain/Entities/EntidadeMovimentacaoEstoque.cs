using ErpProdutos.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ErpProdutos.Domain.Entities
{
    public class EntidadeMovimentacaoEstoque
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public Guid ProdutoId { get; set; }
        public TipoMovimento TipoMovimentacao { get; set; }
        public int Quantidade { get; set; } = 0;
        public decimal ValorVenda { get; set; } = 0;
        public decimal ValorFornecedor { get; set; } = 0;
        public DateTime DataMovimentacao { get; set; } = DateTime.UtcNow;


    }
}
