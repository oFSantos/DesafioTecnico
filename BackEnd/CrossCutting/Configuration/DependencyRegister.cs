
using ErpProdutos.Domain.Interfaces;
using ErpProdutos.Domain.Interfaces.Repositorio;
using ErpProdutos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ErpProdutos.Infrastructure.CrossCutting
{
    public static class DependencyRegister
    {
        public static IServiceCollection AddCrossCuttingServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Conexão com o banco
            var connectionString = configuration.GetConnectionString("PostgresSql");
            services.AddDbContext<ErpProdutosContext>(options =>
                options.UseNpgsql(connectionString));

            //Repositórios
            services.AddScoped<IRepositorioProduto, ProdutoRepository>();
            services.AddScoped<IRepositorioEstoque, EstoqueRepository>();
            services.AddScoped<IRepositorioMovimentacaoEstoque, MovimentacaoEstoqueRepository>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            //Services 
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IMovimentacaoEstoqueService, MovimentacaoEstoqueService>();
            services.AddScoped<IAutenticationService, UsuarioService>();

            return services;
        }
    }
}
