using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SIGO.Autenticacao.Domain.Interfaces;
using SIGO.Autenticacao.Domain.Interfaces.Services;
using SIGO.Autenticacao.Infrastructure.CrossCutting;
using SIGO.Autenticacao.Infrastructure.Data;
using SIGO.Autenticacao.Infrastructure.Data.Context;
using SIGO.Autenticacao.Service.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SIGO.Autenticacao.API
{
    public class Startup
    {
        private readonly string SIGO_API = "SIGO_API";

        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            //mySqlConnectionStr = "server=localhost;port=3306;userid=sysdba;password=dbapwd;database=autenticacao;Persist Security Info=False;Connect Timeout=300;";
            services.AddDbContextPool<MySqlContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddControllers();

            services.AddScoped<IDapperDbConnection, DapperDbConnection>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceUsuario, UsuarioService>();
            services.AddScoped<IServiceToken, TokenService>();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: SIGO_API,
                    builder =>
                    {
                        builder
                        //.WithOrigins("http://localhost:4200")
                        .SetIsOriginAllowed(origin => true)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        ;
                    });
            });

            services.AddSwaggerGen(c =>
            {
                //
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "SIGO.Autenticacao.API",
                        Description = "API de Autenticação e Autorização do Sistema Integrado de Gestão e Operação",
                        Version = "v1"
                    }
                );
                
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
            });


            var chavetoken = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Chavedeacesso");
            var key = Encoding.ASCII.GetBytes(chavetoken.ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIGO.Autenticacao.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(SIGO_API);

            app.UseRouting();

                       
            app.UseAuthentication();
            app.UseAuthorization();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
