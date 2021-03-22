using Microsoft.EntityFrameworkCore;
using SIGO.Normas.Domain.Entities;
using SIGO.Normas.Domain.Enums;
using SIGO.Normas.Infrastructure.Data.Mapping;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Normas.Infrastructure.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Repositorio> Repositorios { get; set; }

        public DbSet<Norma> Normas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.ApplyConfiguration(new RepositorioMapping());
            modelBuilder.ApplyConfiguration(new NormaMapping());

            modelBuilder.Entity<Norma>().HasData(
               new Norma
               {
                   Id = 1,
                   DataCriacao = DateTime.Now,
                   Nome = "ISO 9001",
                   Descricao = "Sistema de Gestao da Qualidade",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "ISO9001.pdf"
               },
               new Norma
               {
                   Id = 2,
                   DataCriacao = DateTime.Now,
                   Nome = "ISO 14001",
                   Descricao = "Sistema de Gestao Ambiental",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "ISO14001.pdf"
               },
               new Norma
               {
                   Id = 3,
                   DataCriacao = DateTime.Now,
                   Nome = "ISO 27001",
                   Descricao = "Sistema de Gestao de Seguranca da Informacao",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "ISO27001.pdf"
               },
               new Norma
               {
                   Id = 4,
                   DataCriacao = DateTime.Now,
                   Nome = "NR 4",
                   Descricao = "Servicos Especializados em Eng. de Seguranca e em Medicina do Trabalho",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "NR4.pdf"
               },
               new Norma
               {
                   Id = 5,
                   DataCriacao = DateTime.Now,
                   Nome = "NR 6",
                   Descricao = "Equipamentos de Protecao Individual - EPI",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "NR6.pdf"
               },
               new Norma
               {
                   Id = 6,
                   DataCriacao = DateTime.Now,
                   Nome = "NR 7",
                   Descricao = "Programas de Controle Medico de Saude Ocupacional - PCMSO",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "NR7.pdf"
               }
            );

            modelBuilder.Entity<Repositorio>().HasData(
               new Repositorio
               {
                   Id = 1,
                   DataCriacao = DateTime.Now,
                   Nome = "Repositorio 1",
                   Descricao = "Repositorio de Normas Fake 1",
                   URL_API = "http://162.243.37.75/normas",
                   Usuario = "sigo",
                   Senha = "sigo",
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
