using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpProdutos.Domain.Enitities;
using ErpProdutos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class RepositorioProduto : IRepositorioProduto
{
    private readonly ErpProdutosContext _contexto;

    public RepositorioProduto(ErpProdutosContext contexto)
    {
        _contexto = contexto;
    }

    //public async Task SalvarMensagemAsync(EntidadeProduto mensagem)
    //{
    //    _contexto.Mensagens.Add(mensagem);
    //    await _contexto.SaveChangesAsync();
    //}

    //public async Task<List<EntidadeProduto>> ObterHistoricoAsync(string remetente, string destinatario)
    //{
    //    return await _contexto.Mensagens
    //        .Where(m => (m.Remetente == remetente && m.Destinatario == destinatario) ||
    //                    (m.Remetente == destinatario && m.Destinatario == remetente))
    //        .OrderBy(m => m.EnviadaEm)
    //        .ToListAsync();
    //}

    public bool CadastrarProduto(EntidadeProduto produto)
    {
        throw new NotImplementedException();
    }

    public bool AtualizarProduto(EntidadeProduto produto)
    {
        throw new NotImplementedException();
    }

    public bool DeletarProduto(Guid idProduto)
    {
        throw new NotImplementedException();
    }

    public EntidadeProduto BuscarProduto(Guid idProduto)
    {
        throw new NotImplementedException();
    }

    public EntidadeProduto BuscarProduto(string codigo)
    {
        throw new NotImplementedException();
    }

    public List<EntidadeProduto> BuscarProdutos(string descricao)
    {
        throw new NotImplementedException();
    }
}
