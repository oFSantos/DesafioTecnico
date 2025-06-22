using ErpProdutos.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ErpProdutos.Domain.Enitities
{
    public class EntidadeMovimentacaoEstoque
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        public Guid ProdutoId { get; set; }
        public TipoMovimento TipoMovimentacao { get; set; }
        public int Quantidade { get; set; } = 0;
        public decimal ValorVenda { get; set; } = 0;
        public decimal ValorFornecedor { get; set; } = 0;
        public DateTime Data { get; set; } = DateTime.UtcNow;


    }
}
