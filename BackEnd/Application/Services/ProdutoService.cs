using ErpProdutos.Config;
using ErpProdutos.Domain.Enitities;
using ErpProdutos.Domain.Interfaces;
using ErpProdutos.Domain.Interfaces.Repositorio;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class ProdutoService : IAutenticationService
{
    private readonly IRepositorioMensagem _usuarioRepositorio;

    public ProdutoService(IRepositorioUsuario usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task RegistrarAsync(string nomeUsuario, string senha)
    {
        var usuarioExistente = await _usuarioRepositorio.BuscarPorNomeAsync(nomeUsuario);
        if (usuarioExistente != null)
            throw new Exception("Usuário já existe.");

        var senhaHash = Helper.HashSenha(senha);
        var usuario = new EntidadeUsuario { NomeUsuario = nomeUsuario, SenhaHash = senhaHash };
        await _usuarioRepositorio.AdicionarUsuarioAsync(usuario);
    }

  
}
