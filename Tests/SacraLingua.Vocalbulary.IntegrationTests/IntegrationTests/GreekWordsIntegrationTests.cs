using Microsoft.Extensions.DependencyInjection;
using SacraLingua.Vocalbulary.Infrastructure.Database;
using SacraLingua.Vocalbulary.IntegrationTests.Mocks.DataFactories;
using SacraLingua.Vocalbulary.IntegrationTests.Setup;
using System.Net;
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

        private async Task SeedGreekWords(TestAppFactory factory)
        {
            using (var scope = factory.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SacraLinguaDbContext>();

                dbContext.GreekWords.Add(GreekWordsFactory.CreateSingle());
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
