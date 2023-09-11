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

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new GreekWordProfile());
            });

            return services;
        }
    }
}
