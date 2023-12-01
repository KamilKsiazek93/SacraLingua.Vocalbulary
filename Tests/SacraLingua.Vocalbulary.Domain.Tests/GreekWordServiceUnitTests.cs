using Moq;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Exceptions;
using SacraLingua.Vocalbulary.Domain.Filters;
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
                .Returns(Task.FromResult(GetAgapeGreekWord()));

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
                .Returns(Task.FromResult(GetAgapeGreekWord()));

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
            Assert.Equal("miłość", polishTranslation.Word);
            Assert.Equal("Bóg jest miłością", polishTranslation.Sentence);
            Assert.Equal("love", englishTranslation.Word);
            Assert.Equal("God is love", englishTranslation.Sentence);
        }

        [Fact]
        public async Task When_GetGreekWordsAsync_Then_Result_Is_PagedResult_Of_GreekWords()
        {
            // Arrange
            GreekWordFilter filter = new GreekWordFilter();
            Mock<IGreekWordRepository> repository = new Mock<IGreekWordRepository>();
            repository
                .Setup(x => x.GetGreekWordAsync(filter))
                .Returns(Task.FromResult(GetPagedResultOfGreekWords()));

            IGreekWordService service = new GreekWordService(
                repository.Object,
                new Mock<IGreekWordLogger>().Object);

            // Act
            PagedResult<GreekWord> result = await service.GetGreekWordAsync(filter);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result.Page);
            Assert.Equal(2, result.PageSize);
            Assert.Equal(2, result.TotalItems);
        }

        private static PagedResult<GreekWord> GetPagedResultOfGreekWords()
            => new PagedResult<GreekWord>(GetListOfGreekWords(), 2, 2, 1);

        private static IReadOnlyList<GreekWord> GetListOfGreekWords()
            => new List<GreekWord>()
            {
                GetAgapeGreekWord(),
                GetPistisGreekWord()
            };

        private static GreekWord GetAgapeGreekWord()
        {
            GreekWord greekWord = new GreekWord("agape", "Theos agape estis", false);
            greekWord.Translations = new List<GreekWordsTranslations>()
            {
                new GreekWordsTranslations() { To = "POL", Word = "miłość", Sentence = "Bóg jest miłością" },
                new GreekWordsTranslations() { To = "ENG", Word = "love", Sentence = "God is love" }
            };

            return greekWord;
        }

        private static GreekWord GetPistisGreekWord()
        {
            GreekWord greekWord = new GreekWord("pistis", "Te gar chariti este sesosmenoi dia pisteos", false);
            greekWord.Translations = new List<GreekWordsTranslations>()
            {
                new GreekWordsTranslations() { To = "POL", Word = "wiara", Sentence = "Albowiem łaską jesteście zbawieni przez wiarę" },
                new GreekWordsTranslations() { To = "ENG", Word = "faith", Sentence = "For by grace are ye saved through faith" }
            };

            return greekWord;
        }
    }
}