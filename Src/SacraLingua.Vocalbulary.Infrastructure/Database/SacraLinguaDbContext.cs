using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
                entity.Property(x => x.Sentence).HasColumnName("Sentence");
                entity.Property(x => x.IsDeleted).HasColumnName("IsDeleted").HasColumnType("tinyint").HasConversion<byte>();
                entity.HasMany(x => x.Translations).WithOne().HasForeignKey(x => x.GreekWordId);
            });

            modelBuilder.Entity<GreekWordsTranslations>(entity =>
            {
                entity.ToTable("GreekWordsTranslations");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.GreekWordId).HasColumnName("GreekWordId");
                entity.Property(x => x.To).HasColumnName("To");
                entity.Property(x => x.Word).HasColumnName("Word");
                entity.Property(x => x.Sentence).HasColumnName("Sentence");
            });
        }
    }
}
