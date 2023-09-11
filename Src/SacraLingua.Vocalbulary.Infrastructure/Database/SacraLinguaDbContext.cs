using Microsoft.EntityFrameworkCore;
using SacraLingua.Vocalbulary.Domain.Entities;

namespace SacraLingua.Vocalbulary.Infrastructure.Database
{
    public class SacraLinguaDbContext : DbContext
    {
        public virtual DbSet<GreekWord> GreekWords { get; set; }

        public SacraLinguaDbContext(DbContextOptions<SacraLinguaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GreekWord>(entity =>
            {
                entity.ToTable("GreekWords");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Word).HasColumnName("Word");
                entity.Property(x => x.WordPolishTranslation).HasColumnName("PolishTranslation");
                entity.Property(x => x.WordEnglishTranslation).HasColumnName("EnglishTranslation");
                entity.Property(x => x.Sentence).HasColumnName("Sentence");
                entity.Property(x => x.SentencePolishTranslation).HasColumnName("PolishSentence");
                entity.Property(x => x.SentenceEnglishTranslation).HasColumnName("EnglishSentence");
            });
        }
    }
}
