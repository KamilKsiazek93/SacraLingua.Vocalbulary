using Microsoft.EntityFrameworkCore;
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
            GreekWordsTranslations polishTranslation = greekWord.Translations.First(x => x.To == "POL");
            GreekWordsTranslations englishTranslation = greekWord.Translations.First(x => x.To == "ENG");

            // Assert
            Assert.Equal("agape", greekWord.Word);
            Assert.Equal("Theos agape estis", greekWord.Sentence);
            Assert.Equal("miłość", polishTranslation.Word);
            Assert.Equal("Bóg jest miłością", polishTranslation.Sentence);
            Assert.Equal("love", englishTranslation.Word);
            Assert.Equal("God is love", englishTranslation.Sentence);
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
                GetSingleGreekWord()
            };

        private GreekWord GetSingleGreekWord()
        {
            GreekWord greekWord = new GreekWord("agape", "Theos agape estis", false);
            greekWord.Translations = new List<GreekWordsTranslations>()
            {
                new GreekWordsTranslations() { To = "POL", Word = "miłość", Sentence = "Bóg jest miłością" },
                new GreekWordsTranslations() { To = "ENG", Word = "love", Sentence = "God is love" }
            };

            return greekWord;
        }
    }
}
