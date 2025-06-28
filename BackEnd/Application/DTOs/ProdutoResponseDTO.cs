using ErpProdutos.Domain.Enums;

public class ProdutoResponseDTO
{
    public Guid Id { get; set; }
    public string Codigo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public TipoProduto Tipo { get; set; }
    public decimal ValorFornecedor { get; set; }
    public DateTime DataCadastro { get; set; }
}
