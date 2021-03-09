using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Sigo.Normas.API
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
            using NormaContext context = new NormaContext();
            
            // Criar o banco de dados se não existir
            context.Database.EnsureCreated();

            // adicionar algumas normas
            context.Norma.Add(new Norma
            {
                Nome = "ISO 9001",
                Descricao = "Sistema de Gestão da Qualidade",
                Status = 1,
                NomeArquivo = "ISO9001.pdf",
                DataCriacao = "",
                DataUltimaAtualizacao = ""
            });

            context.Norma.Add(new Norma
            {
                Nome = "ISO 14001",
                Descricao = "Sistema de Gestão Ambiental",
                Status = 1,
                NomeArquivo = "ISO14001.pdf",
                DataCriacao = "",
                DataUltimaAtualizacao = ""
            });

            context.Norma.Add(new Norma
            {
                Nome = "ISO 27001",
                Descricao = "Sistema Gestão da Segurança da Informação",
                Status = 1,
                NomeArquivo = "ISO27001.pdf",
                DataCriacao = "",
                DataUltimaAtualizacao = ""
            });

            context.Norma.Add(new Norma
            {
                Nome = "NR 4",
                Descricao = "Serviços Especializados em Eng. de Segurança e em Medicina do Trabalho",
                Status = 1,
                NomeArquivo = "NR4.pdf",
                DataCriacao = "",
                DataUltimaAtualizacao = ""
            });

            context.Norma.Add(new Norma
            {
                Nome = "NR 6",
                Descricao = "Equipamentos de Proteção Individual – EPI",
                Status = 1,
                NomeArquivo = "NR6.pdf",
                DataCriacao = "",
                DataUltimaAtualizacao = ""
            });

            context.Norma.Add(new Norma
            {
                Nome = "NR 7",
                Descricao = "Programas de Controle Médico de Saúde Ocupacional – PCMSO",
                Status = 1,
                NomeArquivo = "NR7.pdf",
                DataCriacao = "",
                DataUltimaAtualizacao = ""
            });

            // Saves changes
            context.SaveChanges();
            */
        }
    }
}
