using ErpProdutos.Domain.Entities;

public class ProdutoService : IProdutoService
{
    private readonly IRepositorioProduto _produtoRepository;

    public ProdutoService(IRepositorioProduto produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<bool> CadastrarProduto(EntidadeProduto produto)
    {
        return await _produtoRepository.CadastrarProduto(produto);
    }

    public async Task<bool> AtualizarProduto(EntidadeProduto produto)
    {
        return await _produtoRepository.AtualizarProduto(produto);
    }

    public async Task<bool> DeletarProduto(Guid idProduto)
    {
        return await _produtoRepository.DeletarProduto(idProduto);
    }

    public async Task<EntidadeProduto> BuscarProduto(Guid idProduto)
    {
        return await _produtoRepository.BuscarProduto(idProduto);
    }

    public async Task<EntidadeProduto> BuscarProduto(string codigo)
    {
        return await _produtoRepository.BuscarProduto(codigo);
    }

    public async Task<List<EntidadeProduto>> BuscarProdutos(string descricao)
    {
        return await _produtoRepository.BuscarProdutos(descricao);
    }
    public async Task<IEnumerable<ProdutoResponseDTO>> ListarProdutos()
    {
        var produtos = await _produtoRepository.ListarProdutos();
        return produtos.Select(p => new ProdutoResponseDTO
        {
            Id = p.Id,
            Codigo = p.Codigo,
            Descricao = p.Descricao,
            Tipo = p.Tipo,
            ValorFornecedor = p.ValorFornecedor,
            DataCadastro = p.DataCadastro
        });
    }

}
