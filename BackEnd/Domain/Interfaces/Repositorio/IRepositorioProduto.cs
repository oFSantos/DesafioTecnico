using ErpProdutos.Domain.Enitities;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepositorioProduto
{
    public bool CadastrarProduto(EntidadeProduto produto);
    public bool AtualizarProduto(EntidadeProduto produto);
    public bool DeletarProduto(Guid idProduto);

    public EntidadeProduto BuscarProduto(Guid idProduto);
    public EntidadeProduto BuscarProduto(string codigo);
    public List<EntidadeProduto> BuscarProdutos(string descricao);
}
