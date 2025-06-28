using ErpProdutos.Domain.Enums;

public class ProdutoRequestDTO
{
    public string Codigo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public TipoProduto Tipo { get; set; }
    public decimal ValorFornecedor { get; set; }
}
