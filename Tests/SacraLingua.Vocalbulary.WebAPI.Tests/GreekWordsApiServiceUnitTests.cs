using AutoMapper;
using Moq;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Filters;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;
using SacraLingua.Vocalbulary.WebAPI.Interfaces;
using SacraLingua.Vocalbulary.WebAPI.Mappers;
using SacraLingua.Vocalbulary.WebAPI.Models.Requests;
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

        [Fact]
        public async Task When_GetGreekWordsAsync_Response_Is_PagedResponse_Of_GreekWords()
        {
            // Arrange
            GreekWordFilterRequest filter = new() { Page = 1 };
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new GreekWordProfile()));
            IGreekWordApiService service = new GreekWordApiService(
                GetGreekWordService(),
                new Mock<IGreekWordLogger>().Object,
                mapperConfiguration.CreateMapper());

            // Act
            PagedResponse<GreekWordResponse> response = await service.GetGreekWordAsync(filter);

            // Assert
            Assert.Equal(1, response.Page);
            Assert.Equal(5, response.PageSize);
            Assert.Equal(1, response.TotalItem);
            Assert.Equal(1, response.NumberOfPages);
            Assert.Single(response.Items);
        }

        [Fact]
        public async Task When_DeteleGreekWord_Then_Response_Is_GreekWordResponse()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new GreekWordProfile()));
            IGreekWordApiService service = new GreekWordApiService(
                GetGreekWordService(),
                new Mock<IGreekWordLogger>().Object,
                mapperConfiguration.CreateMapper());

            // Act
            GreekWordResponse response = await service.DeleteGreekWordAsync(1);

            // Assert
            Assert.Equal("agape", response.Word);
        }

        [Fact]
        public async Task When_UpdateGreekWord_Then_Response_Is_GreekWordResponse()
        {
            // Arrange
            GreekWordUpdateRequest request = new();
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new GreekWordProfile()));
            IGreekWordApiService service = new GreekWordApiService(
                GetGreekWordService(),
                new Mock<IGreekWordLogger>().Object,
                mapperConfiguration.CreateMapper());

            // Act
            GreekWordResponse response = await service.UpdateGreekWordAsync(1, request);

            // Assert
            Assert.Equal("agape", response.Word);
        }

        private static IGreekWordService GetGreekWordService()
        {
            Mock<IGreekWordService> service = new();

            service
                .Setup(x => x.GetGreekWordByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(GetGreekWordById(1)));

            service
                .Setup(x => x.GetGreekWordAsync(It.IsAny<GreekWordFilter>()))
                .Returns(Task.FromResult(GetPagedResultOfGreekWords()));

            service
                .Setup(x => x.DeleteGreekWordAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(GetGreekWordById(1)));

            service
                .Setup(x => x.UpdateGreekWordAsync(It.IsAny<int>(), It.IsAny<GreekWord>()))
                .Returns(Task.FromResult(GetGreekWordById(1)));

            return service.Object;
        }

        private static GreekWord GetGreekWordById(int id)
        {
            GreekWord greekWord = new GreekWord("agape", "Theos agape estis", false);
            greekWord.Translations = new List<GreekWordsTranslations>()
            {
                new GreekWordsTranslations() { GreekWordId = id, To = "POL", Word = "miłość", Sentence = "Bóg jest miłością" },
                new GreekWordsTranslations() { GreekWordId = id, To = "ENG", Word = "love", Sentence = "God is love" }
            };

            return greekWord;
        }

        private static PagedResult<GreekWord> GetPagedResultOfGreekWords()
            => new PagedResult<GreekWord>(GetListOfGreekWords(), 1, 5, 1);

        private static IReadOnlyList<GreekWord> GetListOfGreekWords()
            => new List<GreekWord>()
            {
                GetGreekWordById(1)
            };
    }
}
