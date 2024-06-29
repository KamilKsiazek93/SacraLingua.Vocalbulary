using Microsoft.Extensions.DependencyInjection;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;
using SacraLingua.Vocalbulary.Domain.Services;

namespace SacraLingua.Vocalbulary.Domain
{
    public static class Startup
    {
        public static IServiceCollection RegisterDomainAssemblies(this IServiceCollection services)
        {
            services.AddTransient<IGreekWordService, GreekWordService>();
            services.AddTransient<IHebrewWordService, HebrewWordService>();

            return services;
        }
}
}
