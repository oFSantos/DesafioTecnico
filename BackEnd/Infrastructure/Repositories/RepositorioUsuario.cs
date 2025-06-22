using System.Threading.Tasks;
using ErpProdutos.Domain.Enitities;
using ErpProdutos.Domain.Interfaces.Repositorio;
using ErpProdutos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class RepositorioUsuario:IRepositorioUsuario
{
    private readonly ErpProdutosContext _contexto;

    public RepositorioUsuario(ErpProdutosContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<EntidadeUsuario> BuscarPorNomeAsync(string nomeUsuario)
    {
        return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.NomeUsuario == nomeUsuario);
    }

    public async Task AdicionarUsuarioAsync(EntidadeUsuario usuario)
    {
        _contexto.Usuarios.Add(usuario);
        await _contexto.SaveChangesAsync();
    }
}
