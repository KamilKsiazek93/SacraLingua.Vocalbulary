using Moq;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Exceptions;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using SacraLingua.Vocalbulary.Domain.Interfaces.Repositories;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;
using SacraLingua.Vocalbulary.Domain.Services;

namespace SacraLingua.Vocalbulary.Domain.Tests
{
    public class GreekWordServiceUnitTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void When_GetGreekWordById_And_Id_Is_Less_Then_Zero_DomainInvalidIdException_Should_Be_Thrown(int id)
        {
            // Arrange
            Mock<IGreekWordRepository> repository = new Mock<IGreekWordRepository>();
            repository
                .Setup(x => x.GetGreekWordByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(GetSingleGreekWord()));

            IGreekWordService service = new GreekWordService(
                repository.Object,
                new Mock<IGreekWordLogger>().Object);

            // Act & Assert
            await Assert.ThrowsAsync<DomainInvalidIdException>(() => service.GetGreekWordByIdAsync(id));
        }

        [Fact]
        public async void When_GetGreekWordById_And_Id_Is_Valid_GreekWordObject_Should_Be_Retrieved()
        {
            // Arrange
            Mock<IGreekWordRepository> repository = new Mock<IGreekWordRepository>();
            repository
                .Setup(x => x.GetGreekWordByIdAsync(1))
                .Returns(Task.FromResult(GetSingleGreekWord()));

            IGreekWordService service = new GreekWordService(
                repository.Object,
                new Mock<IGreekWordLogger>().Object);

            // Act 
            GreekWord greekWord = await service.GetGreekWordByIdAsync(1);
            GreekWordsTranslations polishTranslation = greekWord.Translations.First(x => x.To == "POL");
            GreekWordsTranslations englishTranslation = greekWord.Translations.First(x => x.To == "ENG");

            // Assert
            Assert.Equal("agape", greekWord.Word);
            Assert.Equal("Theos agape estis", greekWord.Sentence);
            Assert.Equal("mi³oœæ", polishTranslation.Word);
            Assert.Equal("Bóg jest mi³oœci¹", polishTranslation.Sentence);
            Assert.Equal("love", englishTranslation.Word);
            Assert.Equal("God is love", englishTranslation.Sentence);
        }

        private GreekWord GetSingleGreekWord()
        {
            GreekWord greekWord = new GreekWord("agape", "Theos agape estis", false);
            greekWord.Translations = new List<GreekWordsTranslations>()
            {
                new GreekWordsTranslations() { To = "POL", Word = "mi³oœæ", Sentence = "Bóg jest mi³oœci¹" },
                new GreekWordsTranslations() { To = "ENG", Word = "love", Sentence = "God is love" }
            };

            return greekWord;
        }
    }
}