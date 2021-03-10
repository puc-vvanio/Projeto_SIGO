using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sigo.Autenticacao.API.Infrasctructure;
using System.Collections.Generic;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Sigo.Autenticacao.API
{
    public class Startup
    {
        private readonly string SIGO_API = "SIGO_API";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            //string mySqlConnectionStr = Configuration.GetConnectionString("MigrationtConnection"); 
            //string mySqlConnectionStr = "server=localhost;port=3306;userid=sysdba;password=dbapwd;database=seguranca;Persist Security Info=False;Connect Timeout=300;";

            services.AddDbContextPool<AutenticacaoContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddControllers();

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
                        Title = "SIGO.Autenticacao.API",
                        Description = "API de Autenticacao do Sistema Integrado de Gest�o e Opera��o",
                        Version = "v1"
                    }
                );
                // 
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Cabe�alho de autoriza��o JWT usando o esquema Bearer. \r\n\r\n " +
                                      "Enter 'Bearer' [espa�o] e o token gerado na entrada de texto abaixo. \r\n\r\n " +
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
            //
            var chavetoken = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Chavedeacesso").ToString();
            var key = Encoding.ASCII.GetBytes(chavetoken);
            //
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

            /*
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SIGO.Autenticacao.API",
                    Description = "API de Autenticacao do Sistema Integrado de Gest�o e Opera��o",
                    Version = "v1"
                });
            });
            */
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

            app.UseCors(SIGO_API);

            //
            app.UseHttpsRedirection();
            //
            app.UseRouting();
            //
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            //
            app.UseAuthentication();
            app.UseAuthorization();
            //
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });           
        }
    }
}
