using Microsoft.EntityFrameworkCore;
using Sigo.Autenticacao.API.Infrasctructure.EntityConfigurations;
using Sigo.Autenticacao.API.Model;

namespace Sigo.Autenticacao.API.Infrasctructure
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioEntityTypeConfiguration());
        }
    }
}
