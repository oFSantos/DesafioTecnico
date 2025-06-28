using ErpProdutos.Domain.Entities;

public static class EstoqueMapper
{
    public static EstoqueResponseDTO ToResponseDTO(this EntidadeEstoque estoque, EntidadeProduto produto)
    {
        return new EstoqueResponseDTO
        {
            ProdutoId = estoque.ProdutoId,
            CodigoProduto = produto.Codigo,
            DescricaoProduto = produto.Descricao,
            Quantidade = estoque.Quantidade
        };
    }
}
