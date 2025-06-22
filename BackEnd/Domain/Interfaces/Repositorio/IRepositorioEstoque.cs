using ErpProdutos.Domain.Enitities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepositorioEstoque
{
    public bool CadastrarProduto(Guid idProduto, int qnt);
    public bool DeletarProduto(Guid idProduto, int qnt);
    public List<EntidadeEstoque> ConsultarEstoque();
    public List<EntidadeEstoque> ConsultarEstoque(Guid idProduto);

}
