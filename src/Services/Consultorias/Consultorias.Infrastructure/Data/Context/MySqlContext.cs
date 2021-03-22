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
               },
               new Consultoria
               {
                   Id = 2,
                   DataCriacao = DateTime.Now,
                   Nome = "Consultoria 2",
                   Descricao = "Descrição Cosnsultoria 2"
               }
            );

            modelBuilder.Entity<Contrato>().HasData(
               new Contrato
               {
                   Id = 1,
                   DataCriacao = DateTime.Now,
                   Tipo = TipoContrato.Assessoria,
                   Nome = "Contrato 1",
                   Descricao = "Descrição Contrato 1",
                   DataInicio = new DateTime(2020, 10, 5, 0, 0, 0),
                   DataTermino = new DateTime(2021, 10, 5, 0, 0, 0),
                   ConsultoriaID = 1
               },
               new Contrato
               {
                   Id = 2,
                   DataCriacao = DateTime.Now,
                   Tipo = TipoContrato.Consultoria,
                   Nome = "Contrato 2",
                   Descricao = "Descrição Contrato 2",
                   DataInicio = new DateTime(2020, 3, 2, 0, 0, 0),
                   DataTermino = new DateTime(2021, 3, 2, 0, 0, 0),
                   ConsultoriaID = 2
               },
               new Contrato
               {
                   Id = 3,
                   DataCriacao = DateTime.Now,
                   Tipo = TipoContrato.Outro,
                   Nome = "Contrato 3",
                   Descricao = "Descrição Contrato 3",
                   DataInicio = new DateTime(2021, 3, 2, 0, 0, 0),
                   DataTermino = new DateTime(2022, 3, 2, 0, 0, 0),
                   ConsultoriaID = 2
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
