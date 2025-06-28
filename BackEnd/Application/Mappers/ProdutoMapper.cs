using ErpProdutos.Domain.Entities;

public static class ProdutoMapper
{
    public static ProdutoResponseDTO ToResponseDTO(this EntidadeProduto produto)
    {
        return new ProdutoResponseDTO
        {
            Id = produto.Id,
            Codigo = produto.Codigo,
            Descricao = produto.Descricao,
            Tipo = produto.Tipo,
            ValorFornecedor = produto.ValorFornecedor,
            DataCadastro = produto.DataCadastro
        };
    }

    public static EntidadeProduto ToEntity(this ProdutoRequestDTO dto)
    {
        return new EntidadeProduto
        {
            Codigo = dto.Codigo,
            Descricao = dto.Descricao,
            Tipo = dto.Tipo,
            ValorFornecedor = dto.ValorFornecedor
        };
    }
}
