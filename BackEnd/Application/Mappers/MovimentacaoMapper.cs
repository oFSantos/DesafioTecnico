using ErpProdutos.Domain.Entities;

public static class MovimentacaoMapper
{
    public static MovimentacaoEstoqueResponseDTO ToResponseDTO(this EntidadeMovimentacaoEstoque movimentacao, EntidadeProduto produto)
    {
        return new MovimentacaoEstoqueResponseDTO
        {
            Id = movimentacao.Id,
            ProdutoId = movimentacao.ProdutoId,
            CodigoProduto = produto.Codigo,
            DescricaoProduto = produto.Descricao,
            TipoMovimentacao = movimentacao.TipoMovimentacao,
            Quantidade = movimentacao.Quantidade,
            DataMovimentacao = movimentacao.DataMovimentacao
        };
    }
}
