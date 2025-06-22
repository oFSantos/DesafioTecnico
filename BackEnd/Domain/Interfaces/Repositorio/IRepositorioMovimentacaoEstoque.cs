using ErpProdutos.Domain.Enitities;
using ErpProdutos.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepositorioMovimentacaoEstoque
{
    public bool RegistrarMovimentacaoEstoque(EntidadeMovimentacaoEstoque movimentacao);
    public bool ListarMovimentacaoEstoque(TipoMovimento tipoMovimento);
}
