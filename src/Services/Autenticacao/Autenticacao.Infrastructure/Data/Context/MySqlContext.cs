﻿using Microsoft.EntityFrameworkCore;
using SIGO.Autenticacao.Domain.Entities;
using SIGO.Autenticacao.Domain.Enums;
using SIGO.Autenticacao.Infrastructure.CrossCutting.Security;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.ApplyConfiguration(new UsuarioMapping());

            // Hash da senha
            SenhaHelper.CriarSenhaHash("1234", out byte[] senhaHash, out byte[] senhaSalt);

            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {
                   Id = 1,
                   DataCriacao = DateTime.Now,
                   Nome = "Usuario 1",
                   Email = "admin@sigo.com.br",
                   SenhaHash = senhaHash,
                   SenhaSalt = senhaSalt,
                   Perfil = PerfilUsuario.Admin,
                   Status = StatusUsuario.Ativo
               },
               new Usuario
               {
                   Id = 2,
                   DataCriacao = DateTime.Now,
                   Nome = "Usuario 2",
                   Email = "gerente@sigo.com.br",
                   SenhaHash = senhaHash,
                   SenhaSalt = senhaSalt,
                   Perfil = PerfilUsuario.Gerente,
                   Status = StatusUsuario.Ativo
               },
               new Usuario
               {
                   Id = 3,
                   DataCriacao = DateTime.Now,
                   Nome = "Usuario 3",
                   Email = "colaborador@sigo.com.br",
                   SenhaHash = senhaHash,
                   SenhaSalt = senhaSalt,
                   Perfil = PerfilUsuario.Colaborador,
                   Status = StatusUsuario.Ativo
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
