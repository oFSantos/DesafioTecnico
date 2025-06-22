using ErpProdutos.Domain.Enitities;
using System.Text;

namespace ErpProdutos.Domain.Interfaces
{
    public interface IAutenticationService
    {
        public Task RegistrarAsync(string nomeUsuario, string senha);

        
    }
}
