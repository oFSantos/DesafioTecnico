using System.ComponentModel.DataAnnotations;

namespace ErpProdutos.Domain.Enitities
{
    public class EntidadeEstoque
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ProdutoId { get; set; }

        public int QuantidadeAtual { get; set; }


    }
}
