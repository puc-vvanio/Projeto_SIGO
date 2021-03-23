using Microsoft.EntityFrameworkCore;
using SIGO.ProcessoIndustrial.Domain.Entities;
using SIGO.ProcessoIndustrial.Domain.Enums;
using SIGO.ProcessoIndustrial.Infrastructure.Data.Mapping;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.Infrastructure.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<TipoEvento> TiposEventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.ApplyConfiguration(new EventoMapping());
            modelBuilder.ApplyConfiguration(new TipoEventoMapping());

            modelBuilder.Entity<TipoEvento>().HasData(
               new TipoEvento
               {
                   Id = 1,
                   DataCriacao = DateTime.Now,
                   Nome = "Norma Atualizada"
               },
               new TipoEvento
               {
                   Id = 2,
                   DataCriacao = DateTime.Now,
                   Nome = "Norma Cancelada"
               },
               new TipoEvento
               {
                   Id = 3,
                   DataCriacao = DateTime.Now,
                   Nome = "Equipamento em Manutenção"
               },
               new TipoEvento
               {
                   Id = 4,
                   DataCriacao = DateTime.Now,
                   Nome = "Atraso de Matéria Prima"
               },
               new TipoEvento
               {
                   Id = 5,
                   DataCriacao = DateTime.Now,
                   Nome = "Estoque de Produto Acabado"
               }
            );

            modelBuilder.Entity<Evento>().HasData(
               new Evento
               {
                   Id = 1,
                   DataCriacao = DateTime.Now,
                   Nome = "ISO 9001",
                   Descricao = "Atualização de versão",
                   Sistema = Sistema.Normas,
                   TipoEventoID = 1
               },
               new Evento
               {
                   Id = 2,
                   DataCriacao = DateTime.Now,
                   Nome = "Rebobinadeira longitudinal",
                   Descricao = "Precisa realizar manutenção prenventiva",
                   Sistema = Sistema.Processos_Industriais,
                   TipoEventoID = 3
               },
               new Evento
               {
                   Id = 3,
                   DataCriacao = DateTime.Now,
                   Nome = "Liberação de produto",
                   Descricao = "1000 metros do tecido AX2001 liberado para venda",
                   Sistema = Sistema.Vendas,
                   TipoEventoID = 5
               }
            );
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

                    if (entry.Property("DataExclusao").CurrentValue != null)
                        entry.Property("DataExclusao").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
