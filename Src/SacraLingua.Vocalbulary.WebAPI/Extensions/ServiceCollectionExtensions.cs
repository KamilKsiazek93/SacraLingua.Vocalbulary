using Microsoft.OpenApi.Models;
using SacraLingua.Vocalbulary.WebAPI.Interfaces;
using SacraLingua.Vocalbulary.WebAPI.Mappers;
using SacraLingua.Vocalbulary.WebAPI.Services;

namespace SacraLingua.Vocalbulary.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterWebApiAssemblies(this IServiceCollection services)
        {
            services.AddTransient<IGreekWordApiService, GreekWordApiService>();
            services.AddTransient<IHebrewWordApiService, HebrewWordApiService>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new GreekWordProfile());
                cfg.AddProfile(new HebrewWordProfile());
            });

            return services;
        }

        public static IServiceCollection ConfigureSwaggerUI(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sacra Lingua Vocalbulary API", Version = "v1" });

                c.AddSecurityDefinition(Constants.BearerSchemaAuthentication, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = Constants.BearerSchemaAuthentication
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = Constants.BearerSchemaAuthentication
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }
    }
}
