using Microsoft.EntityFrameworkCore;
using Sigo.Normas.API.Infrasctructure.EntityConfigurations;
using Sigo.Normas.API.Model;

namespace Sigo.Normas.API.Infrasctructure
{
    public class NormaContext : DbContext
    {
        public NormaContext(DbContextOptions<NormaContext> options) : base(options)
        {
        }
        public DbSet<Norma> Norma { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NormaEntityTypeConfiguration());
        }
    }
}
