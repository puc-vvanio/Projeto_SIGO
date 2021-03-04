using Microsoft.EntityFrameworkCore;
using SIGO.Consultorias.Domain.Entities;
using SIGO.Consultorias.Domain.Enums;
using SIGO.Consultorias.Infrastructure.Data.Mapping;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Infrastructure.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Contrato> Contratos { get; set; }

        public DbSet<Consultoria> Consultorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.ApplyConfiguration(new ContratoMapping());
            modelBuilder.ApplyConfiguration(new ConsultoriaMapping());

            modelBuilder.Entity<Consultoria>().HasData(
               new Consultoria
               {
                   Id = 1,
                   DataCriacao = DateTime.Now,
                   Nome = "Consultoria 1",
                   Descricao = "Descrição Cosnsultoria 1"
               });

            modelBuilder.Entity<Contrato>().HasData(
               new Contrato
               {
                   Id = 1,
                   DataCriacao = DateTime.Now,
                   Tipo = TipoContrato.Assessoria,
                   Nome = "Contrato 1",
                   Descricao = "Descrição Contrato 1",
                   ConsultoriaID = 1
               });
        }

        public async Task<int> SaveChangesAsync()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;

                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;

                    if (entry.Entity.GetType().GetProperty("GUID") != null)
                        entry.Property("GUID").IsModified = false;

                    if (entry.Property("DataExclusao").CurrentValue != null)
                        entry.Property("DataExclusao").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
