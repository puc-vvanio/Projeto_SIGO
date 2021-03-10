using Microsoft.EntityFrameworkCore;
using SIGO.Autenticacao.Domain.Entities;
using SIGO.Autenticacao.Domain.Enums;
using SIGO.Autenticacao.Infrastructure.Data.Mapping;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Infrastructure.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Autenticacao> Autenticacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new AutenticacaoMapping());

            modelBuilder.Entity<Autenticacao>().HasData(
               new Autenticacao
               {
                   Id = 1,
                   DataCriacao = DateTime.Now,
                   Nome = "Autenticacao 1",
                   Descricao = "Descrição Cosnsultoria 1"
               },
               new Autenticacao
               {
                   Id = 2,
                   DataCriacao = DateTime.Now,
                   Nome = "Autenticacao 2",
                   Descricao = "Descrição Cosnsultoria 2"
               }
            );

            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {
                   Id = 1,
                   DataCriacao = DateTime.Now,
                   Tipo = TipoUsuario.Assessoria,
                   Nome = "Usuario 1",
                   Descricao = "Descrição Usuario 1",
                   AutenticacaoID = 1
               },
               new Usuario
               {
                   Id = 2,
                   DataCriacao = DateTime.Now,
                   Tipo = TipoUsuario.Autenticacao,
                   Nome = "Usuario 2",
                   Descricao = "Descrição Usuario 2",
                   AutenticacaoID = 2
               },
               new Usuario
               {
                   Id = 3,
                   DataCriacao = DateTime.Now,
                   Tipo = TipoUsuario.Outro,
                   Nome = "Usuario 3",
                   Descricao = "Descrição Usuario 3",
                   AutenticacaoID = 2
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
