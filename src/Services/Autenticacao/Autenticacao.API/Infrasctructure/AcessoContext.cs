using Microsoft.EntityFrameworkCore;
using Sigo.Autenticacao.API.Infrasctructure.EntityConfigurations;
using Sigo.Autenticacao.API.Model;

namespace Sigo.Autenticacao.API.Infrasctructure
{
    public class AcessoContext : DbContext
    {
        public AcessoContext(DbContextOptions<AcessoContext> options) : base(options)
        {
        }
        public DbSet<Acesso> Acessos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioEntityTypeConfiguration());
        }
    }
}
