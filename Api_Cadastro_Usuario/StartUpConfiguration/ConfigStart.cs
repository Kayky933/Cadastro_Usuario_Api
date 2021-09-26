using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Repository;
using Api_Cadastro_Usuario.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace Api_Cadastro_Usuario.StartUpConfiguration
{
    public class ConfigStart
    {
        public static void InterfacesConfig(IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<ITasksToDoRepository, TasksToDoRepository>();
            services.AddScoped<ITasksToDoService, TasksToDoService>();
        }
        public static void SwaggerConfig(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type= ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }

                });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_Login_Project", Version = "v1" });

            });
        }      
        public static void CorsConfig(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", config =>
                     config.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .Build()
                );
            });
        }
    }
}
