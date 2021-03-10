using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SIGO.Normas.Domain.Interfaces;
using SIGO.Normas.Domain.Interfaces.Services;
using SIGO.Normas.Infrastructure.CrossCutting;
using SIGO.Normas.Infrastructure.Data;
using SIGO.Normas.Infrastructure.Data.Context;
using SIGO.Normas.Service.Services;

namespace SIGO.Normas.API
{
    public class Startup
    {
        private readonly string SIGO_API = "SIGO_API";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            //mySqlConnectionStr = "server=localhost;port=3306;userid=sysdba;password=dbapwd;database=normastecnicas;Persist Security Info=False;Connect Timeout=300;";
            //string mySqlConnectionStr = Configuration.GetConnectionString("MigrationConnection");
            services.AddDbContextPool<MySqlContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddControllers();

            services.AddScoped<IDapperDbConnection, DapperDbConnection>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceNorma, NormaService>();
            services.AddScoped<IServiceRepositorio, RepositorioService>();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: SIGO_API,
                    builder =>
                    {
                        builder
                        //.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                //
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "SIGO.Normas.API",
                        Description = "API de Normas e Repositórios do Sistema Integrado de Gestão e Operação",
                        Version = "v1"
                    }
                );
                /*
                // 
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Cabeçalho de autorização JWT usando o esquema Bearer.. \r\n\r\n " +
                                      "Enter 'Bearer' [espaço] e o token gerado na entrada de texto abaixo. \r\n\r\n " +
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIGO.Normas.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(SIGO_API);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
