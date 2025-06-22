using ErpProdutos.Domain.Enitities;
using Microsoft.EntityFrameworkCore;

namespace ErpProdutos.Infrastructure.Data
{
    public class ErpProdutosContext:DbContext
    {
        public ErpProdutosContext(DbContextOptions<ErpProdutosContext> options) : base(options) { }
        public DbSet<EntidadeProduto> DbProduto { get; set; }
        public DbSet<EntidadeEstoque> DbEstoque { get; set; }
        public DbSet<EntidadeMovimentacaoEstoque> DbMovimentacaoEstoque { get; set; }
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
