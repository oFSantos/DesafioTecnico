using ErpProdutos.Domain.Entities;
using ErpProdutos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

public class ProdutoRepository : IRepositorioProduto
{
    private readonly ErpProdutosContext _context;

    public ProdutoRepository(ErpProdutosContext context)
    {
        _context = context;
    }

    public async Task<bool> CadastrarProduto(EntidadeProduto produto)
    {
        await _context.Produto.AddAsync(produto);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AtualizarProduto(EntidadeProduto produto)
    {
        _context.Produto.Update(produto);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeletarProduto(Guid idProduto)
    {
        var produto = await _context.Produto.FindAsync(idProduto);
        if (produto == null) return false;
        _context.Produto.Remove(produto);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<EntidadeProduto> BuscarProduto(Guid idProduto)

    {
        return await _context.Produto
            .FirstOrDefaultAsync(p => p.Id == idProduto);
    }

    public async Task<EntidadeProduto> BuscarProduto(string codigo)
    {
        return await _context.Produto
            .FirstOrDefaultAsync(p => p.Codigo == codigo);
    }

    public async Task<List<EntidadeProduto>> BuscarProdutos(string descricao)
    {
        return await _context.Produto
            .Where(p => p.Descricao.Contains(descricao))
            .ToListAsync();
    }
    public async Task<IEnumerable<EntidadeProduto>> ListarProdutos()
    {
        return await _context.Produto.ToListAsync();
    }


}
