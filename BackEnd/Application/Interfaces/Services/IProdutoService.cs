using ErpProdutos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProdutoService
{
    public Task<bool> CadastrarProduto(EntidadeProduto produto);
    public Task<bool> AtualizarProduto(EntidadeProduto produto);
    public Task<bool> DeletarProduto(Guid idProduto);

    public Task<EntidadeProduto> BuscarProduto(Guid idProduto);
    public Task<EntidadeProduto> BuscarProduto(string codigo);
    public Task<List<EntidadeProduto>> BuscarProdutos(string descricao);
    public Task<IEnumerable<ProdutoResponseDTO>> ListarProdutos();
}
