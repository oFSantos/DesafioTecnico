using System.ComponentModel.DataAnnotations;

namespace ErpProdutos.Domain.Entities
{
    public class EntidadeEstoque
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProdutoId { get; set; }

        public int Quantidade { get; set; }


    }
}
