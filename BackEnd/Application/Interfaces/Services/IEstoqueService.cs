using ErpProdutos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEstoqueService
{
    public Task<bool> AdicionarProduto(string codigo, int qnt);
    public Task<bool> RemoverProduto(string codigo, int qnt);
    public Task<List<EntidadeEstoque>> ListarEstoque();

}
