using Microsoft.EntityFrameworkCore;
using Moq;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Exceptions;
using SacraLingua.Vocalbulary.Domain.Interfaces.Repositories;
using SacraLingua.Vocalbulary.Infrastructure.Database;
using SacraLingua.Vocalbulary.Infrastructure.Repositories;
using SacraLingua.Vocalbulary.Infrastructure.Tests.Mockups;

namespace SacraLingua.Vocalbulary.Infrastructure.Tests
{
    public class GreekWordsRepositoryUnitTests
    {
        [Fact]
        public async Task When_GetGreekWordsById_Then_GreekWords_Should_Be_Retrieved()
        {
            // Arrange
            IGreekWordRepository repository = new GreekWordRepository(GetDbContext());

            // Act
            GreekWord greekWord = await repository.GetGreekWordByIdAsync(1);

            // Assert
            Assert.Equal(1, greekWord.Id);
            Assert.Equal("agape", greekWord.Word);
            Assert.Equal("miłość", greekWord.WordPolishTranslation);
            Assert.Equal("love", greekWord.WordEnglishTranslation);
            Assert.Equal("Theos agape estis", greekWord.Sentence);
            Assert.Equal("Bóg jest miłością", greekWord.SentencePolishTranslation);
            Assert.Equal("God is love", greekWord.SentenceEnglishTranslation);
        }

        [Fact]
        public async Task When_GetGreekWordsById_And_GreekWordNonExist_Then_Exception_Should_Be_Thrown()
        {
            // Arrange
            IGreekWordRepository repository = new GreekWordRepository(GetDbContext());

            // Act & Assert
            await Assert.ThrowsAsync<DomainEntityNotFoundException>(() => repository.GetGreekWordByIdAsync(0));
        }

        private SacraLinguaDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<SacraLinguaDbContext>()
                .UseInMemoryDatabase(databaseName: "SacraLingua")
                .Options;

            SacraLinguaDbContext dbContext = new InMemoryDbContext(options);

            GetGreekWords().ForEach(greekWord => dbContext.Add(greekWord));
            dbContext.SaveChanges();

            return dbContext;
        }

        private List<GreekWord> GetGreekWords()
            => new List<GreekWord>
            {
                new GreekWord(1, "agape", "miłość", "love", "Theos agape estis", "Bóg jest miłością", "God is love")
            };
    }
}
