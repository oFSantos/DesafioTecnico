using ErpProdutos.Domain.Enums;

public class MovimentacaoEstoqueResponseDTO
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public string CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; }
    public TipoMovimento TipoMovimentacao { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataMovimentacao { get; set; }
}
