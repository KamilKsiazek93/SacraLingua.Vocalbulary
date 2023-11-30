using AutoMapper;
using Moq;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;
using SacraLingua.Vocalbulary.WebAPI.Interfaces;
using SacraLingua.Vocalbulary.WebAPI.Mappers;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;
using SacraLingua.Vocalbulary.WebAPI.Services;

namespace SacraLingua.Vocalbulary.WebAPI.Tests
{
    public class GreekWordsApiServiceUnitTests
    {
        [Fact]
        public async Task When_GetGreekWordsById_Then_GreekWordsResponse_Should_Be_Retrieved()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new GreekWordProfile()));
            IGreekWordApiService service = new GreekWordApiService(
                GetGreekWordService(),
                new Mock<IGreekWordLogger>().Object,
                mapperConfiguration.CreateMapper());

            // Act
            GreekWordResponse response = await service.GetGreekWordByIdAsync(1);
            GreekWordTranslationResponse polishTranslation = response.Translations.First(x => x.To == "POL");
            GreekWordTranslationResponse englishTranslation = response.Translations.First(x => x.To == "ENG");

            // Assert
            Assert.Equal("agape", response.Word);
            Assert.Equal("miłość", polishTranslation.Word);
            Assert.Equal("Theos agape estis", response.Sentence);
            Assert.Equal("Bóg jest miłością", polishTranslation.Sentence);
            Assert.Equal("love", englishTranslation.Word);
            Assert.Equal("God is love", englishTranslation.Sentence);
        }

        private IGreekWordService GetGreekWordService()
        {
            Mock<IGreekWordService> service = new();

            service
                .Setup(x => x.GetGreekWordByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(GetGreekWordById(1)));

            return service.Object;
        }

        private GreekWord GetGreekWordById(int id)
        {
            GreekWord greekWord = new GreekWord("agape", "Theos agape estis", false);
            greekWord.Translations = new List<GreekWordsTranslations>()
            {
                new GreekWordsTranslations() { GreekWordId = id, To = "POL", Word = "miłość", Sentence = "Bóg jest miłością" },
                new GreekWordsTranslations() { GreekWordId = id, To = "ENG", Word = "love", Sentence = "God is love" }
            };

            return greekWord;
        }
    }
}
