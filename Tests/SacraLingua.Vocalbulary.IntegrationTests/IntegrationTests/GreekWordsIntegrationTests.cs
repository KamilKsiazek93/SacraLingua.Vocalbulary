using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SacraLingua.Vocalbulary.Infrastructure.Database;
using SacraLingua.Vocalbulary.IntegrationTests.Mocks.DataFactories;
using SacraLingua.Vocalbulary.IntegrationTests.Setup;
using SacraLingua.Vocalbulary.WebAPI.Models.Requests;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;
using System.Net;
using System.Text;
using System.Text.Json;
using Xunit;

namespace SacraLingua.Vocalbulary.IntegrationTests.IntegrationTests
{
    public class GreekWordsIntegrationTests : IClassFixture<TestAppFactory>
    {
        private const string GreekWordsUri = "/api/v1/greek-words";

        [Fact]
        public async Task When_GetGreekWords_Then_Response_Is_Ok()
        {
            // Arrange
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);

            // Act

            var response = await client.GetAsync($"{GreekWordsUri}/1");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task When_GetGreekWordsByNonExistingId_Then_Response_Is_NotFound()
        {
            // Arrange
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);

            // Act

            var response = await client.GetAsync($"{GreekWordsUri}/100");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task When_GetGreekWordsByInvalidId_Then_Response_Is_BadRequest()
        {
            // Arrange
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);

            // Act

            var response = await client.GetAsync($"{GreekWordsUri}/0");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task When_GetGeekWordAsync_Response_Is_Ok()
        {
            // Arrange
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);

            // Act
            HttpResponseMessage response = await client.GetAsync($"{GreekWordsUri}");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task When_GetGreekWordAsync_With_Filter_Response_Is_Ok()
        {
            // Arrange
            GreekWordFilterRequest filter = new GreekWordFilterRequest() {  Word = "agape"};
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);
            string url = $"{GreekWordsUri}?Word={filter.Word}";

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task When_GetGreekWordsAsync_WithoutFilter_Default_Paging_Should_Be_Apply()
        {
            // Arrange
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);

            // Act
            HttpResponseMessage response = await client.GetAsync($"{GreekWordsUri}");

            // Assert
            string stringResponse = await response.Content.ReadAsStringAsync();
            PagedResponse<GreekWordResponse> greekWordResponse = JsonConvert.DeserializeObject<PagedResponse<GreekWordResponse>>(stringResponse);

            Assert.Equal(1, greekWordResponse.Page);
            Assert.Equal(25, greekWordResponse.PageSize);
        }

        [Fact]
        public async Task When_GetGreekWordsAsync_WithFilter_Response_Is_PagedResponse_With_MatchingCriteriaItems()
        {
            // Arrange
            GreekWordFilterRequest filter = new GreekWordFilterRequest() { Word = "agape" };
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);
            string url = $"{GreekWordsUri}?Word={filter.Word}";

            // Act
            HttpResponseMessage response = await client.GetAsync(url);

            // Assert
            string stringResponse = await response.Content.ReadAsStringAsync();
            PagedResponse<GreekWordResponse>? greekWordResponse = JsonConvert.DeserializeObject<PagedResponse<GreekWordResponse>>(stringResponse);

            Assert.Single(greekWordResponse.Items);
        }

        [Fact]
        public async Task When_DeleteGreekWord_Then_Response_Is_Ok()
        {
            // Arrange
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);

            // Act
            HttpResponseMessage response = await client.DeleteAsync($"{GreekWordsUri}/1");

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task When_DeleteGreekWord_ByNonExistingId_Then_Response_Is_NotFound()
        {
            // Arrange
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);

            // Act
            HttpResponseMessage response = await client.DeleteAsync($"{GreekWordsUri}/100");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task When_DeleteGreekWord_Response_Contain_GreekWord_With_Id()
        {
            // Arrange
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);

            // Act
            HttpResponseMessage response = await client.DeleteAsync($"{GreekWordsUri}/1");

            // Assert
            string stringResponse = await response.Content.ReadAsStringAsync();
            GreekWordResponse? greekWordResponse = JsonConvert.DeserializeObject<GreekWordResponse>(stringResponse);

            Assert.Equal(1, greekWordResponse?.Id);
        }

        [Fact]
        public async Task When_UpdateGreekWord_Then_Response_Is_Ok()
        {
            // Arrange
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);
            GreekWordUpdateRequest request = new()
            {
                Word = "updatedWord",
                Sentence = "updatedSentence"
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(request, new JsonSerializerOptions());
            StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await client.PutAsync($"{GreekWordsUri}/1", httpContent);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task When_UpdateGreekWordByNonExistingId_Then_Response_Is_NotFound()
        {
            // Arrange
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);
            GreekWordUpdateRequest request = new()
            {
                Word = "updatedWord",
                Sentence = "updatedSentence"
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(request, new JsonSerializerOptions());
            StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await client.PutAsync($"{GreekWordsUri}/100", httpContent);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task When_UpdateGreekWord_Then_Response_Contains_Updated_GreekWord()
        {
            var factory = new TestAppFactory();
            var client = factory.CreateClient();
            await SeedGreekWords(factory);
            GreekWordUpdateRequest request = new()
            {
                Word = "updatedWord",
                Sentence = "updatedSentence"
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(request, new JsonSerializerOptions());
            StringContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await client.PutAsync($"{GreekWordsUri}/1", httpContent);

            // Assert
            string stringResponse = await response.Content.ReadAsStringAsync();
            GreekWordResponse? greekWordResponse = JsonConvert.DeserializeObject<GreekWordResponse>(stringResponse);

            Assert.Equal(1, greekWordResponse?.Id);
            Assert.Equal("updatedWord", greekWordResponse?.Word);
            Assert.Equal("updatedSentence", greekWordResponse?.Sentence);
        }

        private async Task SeedGreekWords(TestAppFactory factory)
        {
            using (var scope = factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SacraLinguaDbContext>();

                await dbContext.GreekWords.AddRangeAsync(GreekWordsFactory.CreateMultiple());
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
