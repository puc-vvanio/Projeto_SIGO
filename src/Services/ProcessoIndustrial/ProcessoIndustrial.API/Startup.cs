using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SIGO.ProcessoIndustrial.API.Consumers;
using SIGO.ProcessoIndustrial.API.Helpers;
using SIGO.ProcessoIndustrial.Domain.Interfaces;
using SIGO.ProcessoIndustrial.Domain.Interfaces.Services;
using SIGO.ProcessoIndustrial.Infrastructure.CrossCutting;
using SIGO.ProcessoIndustrial.Infrastructure.Data;
using SIGO.ProcessoIndustrial.Infrastructure.Data.Context;
using SIGO.ProcessoIndustrial.Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.ProcessoIndustrial.API
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
            //mySqlConnectionStr = "server=localhost;port=3306;userid=sysdba;password=dbapwd;database=processoindustrial;Persist Security Info=False;Connect Timeout=300;";
            services.AddDbContextPool<MySqlContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
            /*
            // inicializar as configura��es para rabbitmq e masstransit, configurar consumidores e iniciar o bus service
            services.Configure<RabbitmqConfig>(Configuration.GetSection("RabbitMQConfigurations"));

            services.AddMassTransit(x =>
            {
                var configSections = Configuration.GetSection("RabbitMQConfigurations");
                var host = configSections["Host"];
                var userName = configSections["UserName"];
                var password = configSections["Password"];
                var virtualHost = configSections["VirtualHost"];
                var port = Convert.ToUInt16(configSections["Port"]);

                x.AddConsumer<SubscriptionSuccessfulConsumer>();

                x.AddBus(provider =>
                {
                    var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host(host, port, virtualHost, host =>
                        {
                            host.Username(userName);
                            host.Password(password);
                        });

                        cfg.ReceiveEndpoint(configSections["Endpoint"], ep =>
                        {
                            ep.PrefetchCount = Convert.ToUInt16(configSections["PrefetchCount"]);

                            ep.ConfigureConsumer<SubscriptionSuccessfulConsumer>(provider);
                        });
                    });

                    bus.Start();

                    return bus;
                });
            });

            services.Configure<HealthCheckPublisherOptions>(options =>
            {
                options.Delay = TimeSpan.FromSeconds(2);
                options.Predicate = (check) => check.Tags.Contains("ready");
            });

            services.AddMassTransitHostedService();
            */
            services.AddControllers();

            services.AddScoped<IDapperDbConnection, DapperDbConnection>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceEvento, EventoService>();
            services.AddScoped<IServiceTipoEvento, TipoEventoService>();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: SIGO_API,
                    builder =>
                    {
                        builder
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
                        Title = "SIGO.ProcessoIndustrial.API",
                        Description = "API de Gest�o do Processo Industrial do Sistema Integrado de Gest�o e Opera��o",
                        Version = "v1"
                    }
                );
                // 
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Cabe�alho de autoriza��o JWT usando o esquema Bearer.. \r\n\r\n " +
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIGO.ProcessoIndustrial.API v1"));
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
