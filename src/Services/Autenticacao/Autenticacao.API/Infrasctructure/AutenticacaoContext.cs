using Microsoft.EntityFrameworkCore;
using Sigo.Autenticacao.API.Infrasctructure.EntityConfigurations;
using Sigo.Autenticacao.API.Model;

namespace Sigo.Autenticacao.API.Infrasctructure
{
    public class AutenticacaoContext : DbContext
    {
        public AutenticacaoContext(DbContextOptions<AutenticacaoContext> options) : base(options)
        {
        }
        public DbSet<Acesso> Acessos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new AutenticacaoEntityTypeConfiguration());
        }
    }
 }
