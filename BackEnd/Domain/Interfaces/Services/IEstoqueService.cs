using ErpProdutos.Domain.Enitities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEstoqueService
{
    public bool AdicionarProduto(Guid idProduto, int qnt);
    public bool RemoverProduto(Guid idProduto, int qnt);
    public List<EntidadeEstoque> ListarEstoque();

}
