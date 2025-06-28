using ErpProdutos.Domain.Entities;

namespace ErpProdutos.Domain.Interfaces.Repositorio
{
    public interface IRepositorioUsuario
    {
        public Task<EntidadeUsuario> BuscarPorNomeAsync(string nomeUsuario);
        public Task AdicionarUsuarioAsync(EntidadeUsuario usuario);
     
    }
}
