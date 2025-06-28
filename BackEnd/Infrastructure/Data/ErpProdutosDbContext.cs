using ErpProdutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ErpProdutos.Infrastructure.Data
{
    public class ErpProdutosContext:DbContext
    {
        public ErpProdutosContext(DbContextOptions<ErpProdutosContext> options) : base(options) { }
        public DbSet<EntidadeProduto> Produto { get; set; }
        public DbSet<EntidadeEstoque> Estoque { get; set; }
        public DbSet<EntidadeMovimentacaoEstoque> MovimentacaoEstoque { get; set; }
        public DbSet<EntidadeUsuario> Usuarios { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<EntidadeUsuario>()
                .HasIndex(u => u.NomeUsuario)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
