using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpProdutos.Domain.Enitities;
using ErpProdutos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class RepositorioEstoque : IRepositorioEstoque
{
    private readonly ErpProdutosContext _contexto;

    public RepositorioEstoque(ErpProdutosContext contexto)
    {
        _contexto = contexto;
    }

    public bool CadastrarProduto(Guid idProduto, int qnt)
    {
        throw new NotImplementedException();
    }

    public List<EntidadeEstoque> ConsultarEstoque()
    {
        throw new NotImplementedException();
    }

    public List<EntidadeEstoque> ConsultarEstoque(Guid idProduto)
    {
        throw new NotImplementedException();
    }

    public bool DeletarProduto(Guid idProduto, int qnt)
    {
        throw new NotImplementedException();
    }
}
