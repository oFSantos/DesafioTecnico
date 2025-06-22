using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ErpProdutos.Infrastructure.Data;
using ErpProdutos.Domain.Interfaces;
using ErpProdutos.Domain.Interfaces.Repositorio;

namespace ErpProdutos.Infrastructure.CrossCutting
{
    public static class DependencyRegister
    {
        public static IServiceCollection AddCrossCuttingServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            var connectionString = configuration.GetConnectionString("PostgresSql");
            
            services.AddDbContext<ErpProdutosContext>(options =>
                options.UseNpgsql(connectionString));
            services.AddScoped<IRepositorioMensagem, RepositorioProduto>();
            services.AddSignalR();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<IAutenticationService, UsuarioService>();            

            return services;
        }
    }
}
