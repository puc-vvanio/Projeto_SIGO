using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SIGO.Consultorias.Infrastructure.Data.Context;

namespace SIGO.Consultorias.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContextPool<MySqlContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
            services.AddDbContextPool<MySqlContext>(options => options
                .UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr))
                .UseLoggerFactory(LoggerFactory.Create(b => b
                    .AddConsole()
                    .AddFilter(level => true)))
                .EnableSensitiveDataLogging());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "SIGO.Consultorias.API",
                        Description = "API de Consultorias e Acessorias do Sistema Integrado de Gestão e Operação",
                        Version = "v1"
                    }
                );
                /*
                // 
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Cabeçalho de autorização JWT usando o esquema Bearer.. \r\n\r\n " +
                                      "Enter 'Bearer' [spaço] e o token gerado na entrada de texto abaixo. \r\n\r\n " +
                                      "Example: \"Bearer TOKEN GERADO\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    }
                );
                // 
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                            },
                            new List<string>()
                        }
                    }
                );
                */
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIGO.Consultorias.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
