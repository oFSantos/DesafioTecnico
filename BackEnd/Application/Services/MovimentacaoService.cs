using ErpProdutos.Domain.Entities;
using ErpProdutos.Domain.Enums;

public class MovimentacaoEstoqueService : IMovimentacaoEstoqueService
{
    private readonly IRepositorioMovimentacaoEstoque _movimentacaoRepository;

    public MovimentacaoEstoqueService(IRepositorioMovimentacaoEstoque movimentacaoRepository)
    {
        _movimentacaoRepository = movimentacaoRepository;
    }

    public async Task<List<EntidadeMovimentacaoEstoque>> ListarMovimentacaoEstoque(TipoMovimento tipoMovimento)
    {
        return await _movimentacaoRepository.ListarMovimentacaoEstoque(tipoMovimento);
    }

    public async Task<bool> RegistrarMovimentacaoEstoque(EntidadeMovimentacaoEstoque movimentacao)
    {
        return await _movimentacaoRepository.RegistrarMovimentacaoEstoque(movimentacao);
    }
}
