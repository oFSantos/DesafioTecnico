using ErpProdutos.Domain.Entities;
using ErpProdutos.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepositorioMovimentacaoEstoque
{
    public Task<bool> RegistrarMovimentacaoEstoque(EntidadeMovimentacaoEstoque movimentacao);
    public Task<List<EntidadeMovimentacaoEstoque>> ListarMovimentacaoEstoque(TipoMovimento tipoMovimento);
}
