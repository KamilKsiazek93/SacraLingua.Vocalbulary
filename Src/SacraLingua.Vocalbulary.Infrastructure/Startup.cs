using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SacraLingua.Vocalbulary.Domain.Interfaces.Repositories;
using SacraLingua.Vocalbulary.Infrastructure.Database;
using SacraLingua.Vocalbulary.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using SacraLingua.Vocalbulary.Infrastructure.Loggers;

namespace SacraLingua.Vocalbulary.Infrastructure
{
    public static class Startup
    {
        public static IServiceCollection RegisterInfrastructureAssemblies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGreekWordRepository, GreekWordRepository>();
            services.AddDbContext<SacraLinguaDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SacraLinguaDbConnectionString")));

            services.AddTransient<IGreekWordLogger, GreekWordLogger>();

            return services;
        }
    }
}
