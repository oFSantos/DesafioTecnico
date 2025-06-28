using ErpProdutos.Domain.Entities;
using ErpProdutos.Domain.Enums;
using ErpProdutos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

public class MovimentacaoEstoqueRepository : IRepositorioMovimentacaoEstoque
{
    private readonly ErpProdutosContext _context;

    public MovimentacaoEstoqueRepository(ErpProdutosContext context)
    {
        _context = context;
    }

    public async Task<bool> RegistrarMovimentacaoEstoque(EntidadeMovimentacaoEstoque movimentacao)
    {
        await _context.MovimentacaoEstoque.AddAsync(movimentacao);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<EntidadeMovimentacaoEstoque>> ListarMovimentacaoEstoque(TipoMovimento tipoMovimento)
    {
        return await _context.MovimentacaoEstoque
            .Where(m => m.TipoMovimentacao == tipoMovimento)
            .ToListAsync();
    }

 
}
