using Microsoft.EntityFrameworkCore;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Infrastructure.Database;

namespace SacraLingua.Vocalbulary.Infrastructure.Tests.Mockups
{
    internal class InMemoryDbContext : SacraLinguaDbContext
    {
        private Guid _id;
        public override DbSet<GreekWord> GreekWords { get; set; }
        public InMemoryDbContext(DbContextOptions<SacraLinguaDbContext> options) : base(options)
        {
            _id = Guid.NewGuid();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_id.ToString());
        }
    }
}
