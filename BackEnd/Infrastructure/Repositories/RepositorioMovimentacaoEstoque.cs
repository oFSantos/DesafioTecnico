using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpProdutos.Domain.Enitities;
using ErpProdutos.Domain.Enums;
using ErpProdutos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class RepositorioMovimentacaoEstoque : IRepositorioMovimentacaoEstoque
{
    private readonly ErpProdutosContext _contexto;

    public RepositorioMovimentacaoEstoque(ErpProdutosContext contexto)
    {
        _contexto = contexto;
    }

    public bool ListarMovimentacaoEstoque(TipoMovimento tipoMovimento)
    {
        throw new NotImplementedException();
    }

    public bool RegistrarMovimentacaoEstoque(EntidadeMovimentacaoEstoque movimentacao)
    {
        throw new NotImplementedException();
    }
}
