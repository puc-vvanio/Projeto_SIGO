using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Sigo.Autenticacao.API.Infrasctructure;
using Sigo.Autenticacao.API.Model;
using System;

namespace Sigo.Autenticacao.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            InsertData();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void InsertData()
        {

            /*
            using AutenticacaoContext context = null;
            
            // Criar o banco de dados se não existir
            context.Database.EnsureCreated();

            // adicionar algumas normas
            context.Usuarios.Add(new Usuario
            {
                Nome = "IAdmin",
                Email = "admin@sigo.com.br",
                Senha = "admin",
                Status = 1,
                DataCriacao = DateTime.Now,
                DataUltimaAtualizacao = DateTime.Now
            });            

            // Saves changes
            context.SaveChanges();    
            */
        }
    }
}
