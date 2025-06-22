using ErpProdutos.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ErpProdutos.Domain.Enitities
{
    public class EntidadeProduto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Codigo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public TipoProduto Tipo { get; set; }
        public decimal ValorFornecedor { get; set; }
        public decimal ValorVenda { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
      

    }
}
