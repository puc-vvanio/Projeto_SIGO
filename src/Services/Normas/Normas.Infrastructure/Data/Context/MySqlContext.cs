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
                   Nome = "ISO 9001",
                   Descricao = "Sistema de Gestao da Qualidade",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "ISO9001.pdf"
               },
               new Norma
               {
                   Id = 2,
                   Nome = "ISO 14001",
                   Descricao = "Sistema de Gestao Ambiental",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "ISO14001.pdf"
               },
               new Norma
               {
                   Id = 3,
                   Nome = "ISO 27001",
                   Descricao = "Sistema de Gestao de Seguranca da Informacao",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "ISO27001.pdf"
               },
               new Norma
               {
                   Id = 4,
                   Nome = "NR 4",
                   Descricao = "Servicos Especializados em Eng. de Seguranca e em Medicina do Trabalho",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "NR4.pdf"
               },
               new Norma
               {
                   Id = 5,
                   Nome = "NR 6",
                   Descricao = "Equipamentos de Protecao Individual - EPI",
                   Tipo = TipoNorma.Nacional,
                   Status = StatusNorma.Vigor,
                   NomeArquivo = "NR6.pdf"
               },
               new Norma
               {
                   Id = 6,
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
                   Nome = "Repositorio 1",
                   Descricao = "Descrição Repositorio 1",
                   URL_API = "http://api.repositorio1.com.br",
                   Usuario = "sigo1",
                   Senha = "sigo1",
               },
               new Repositorio
               {
                   Id = 2,
                   Nome = "Repositorio 2",
                   Descricao = "Descrição Repositorio 2",
                   URL_API = "http://api.repositorio2.com.br",
                   Usuario = "sigo2",
                   Senha = "sigo2",
               },
               new Repositorio
               {
                   Id =31,
                   Nome = "Repositorio 3",
                   Descricao = "Descrição Repositorio 3",
                   URL_API = "http://api.repositorio3.com.br",
                   Usuario = "sigo3",
                   Senha = "sigo3",
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
