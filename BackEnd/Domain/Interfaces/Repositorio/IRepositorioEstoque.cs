using ErpProdutos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepositorioEstoque
{
    public Task<bool> CadastrarProduto(Guid idProduto, int qnt);
    public Task<bool> DeletarProduto(Guid idProduto, int qnt);
    public Task<List<EntidadeEstoque>> ConsultarEstoque();
    public Task<List<EntidadeEstoque>> ConsultarEstoque(Guid idProduto);
    public  Task<bool> AtualizarEstoque(Guid idProduto, int novaQuantidade);

}
