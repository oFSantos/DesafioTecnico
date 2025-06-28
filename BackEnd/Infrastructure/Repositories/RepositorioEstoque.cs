using ErpProdutos.Domain.Entities;
using ErpProdutos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

public class EstoqueRepository : IRepositorioEstoque
{
    private readonly ErpProdutosContext _context;

    public EstoqueRepository(ErpProdutosContext context)
    {
        _context = context;
    }

    public async Task<bool> CadastrarProduto(Guid idProduto, int qnt)
    {
        var estoque = new EntidadeEstoque
        {
            ProdutoId = idProduto,
            Quantidade = qnt
        };
        await _context.Estoque.AddAsync(estoque);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AtualizarEstoque(Guid idProduto, int novaQuantidade)
    {
        var estoque = await _context.Estoque.FirstOrDefaultAsync(e => e.ProdutoId == idProduto);
        if (estoque == null)
            return false;

        estoque.Quantidade = novaQuantidade;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletarProduto(Guid idProduto, int qnt)
    {
        var estoque = await _context.Estoque
            .FirstOrDefaultAsync(e => e.ProdutoId == idProduto);
        if (estoque == null || estoque.Quantidade < qnt) return false;

        estoque.Quantidade -= qnt;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<EntidadeEstoque>> ConsultarEstoque()
    {
        return await _context.Estoque.ToListAsync();
    }

    public async Task<List<EntidadeEstoque>> ConsultarEstoque(Guid idProduto)
    {
        return await _context.Estoque
            .Where(e => e.ProdutoId == idProduto)
            .ToListAsync();
    }

}
