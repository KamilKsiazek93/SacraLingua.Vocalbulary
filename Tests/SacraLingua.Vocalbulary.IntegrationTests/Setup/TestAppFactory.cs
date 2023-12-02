using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacraLingua.Vocalbulary.Infrastructure.Database;
using SacraLingua.Vocalbulary.IntegrationTests.Mocks;

namespace SacraLingua.Vocalbulary.IntegrationTests.Setup
{
    public class TestAppFactory : WebApplicationFactory<Program>, IDisposable
    {
        private bool disposed = false;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IPolicyEvaluator, MockAutorizationPolicy>();
            });

            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<SacraLinguaDbContext>(GetDbContext());
            });
        }

        private InMemoryDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<SacraLinguaDbContext>()
                .UseInMemoryDatabase(databaseName: "SacraLingua")
                .Options;

            return new InMemoryDbContext(options);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }
                disposed = true;
            }
        }
    }
}
