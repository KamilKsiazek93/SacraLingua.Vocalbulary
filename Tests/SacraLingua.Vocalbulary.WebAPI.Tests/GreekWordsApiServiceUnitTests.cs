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

            // Assert
            Assert.Equal("agape", response.Word);
            Assert.Equal("miłość", response.WordPolishTranslation);
            Assert.Equal("love", response.WordEnglishTranslation);
            Assert.Equal("Theos agape estis", response.Sentence);
            Assert.Equal("Bóg jest miłością", response.SentencePolishTranslation);
            Assert.Equal("God is love", response.SentenceEnglishTranslation);
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
            => new GreekWord("agape", "miłość", "love", "Theos agape estis", "Bóg jest miłością", "God is love");
    }
}
