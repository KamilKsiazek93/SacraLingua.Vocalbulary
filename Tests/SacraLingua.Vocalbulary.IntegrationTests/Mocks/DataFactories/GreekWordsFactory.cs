using SacraLingua.Vocalbulary.Domain.Entities;

namespace SacraLingua.Vocalbulary.IntegrationTests.Mocks.DataFactories
{
    internal static class GreekWordsFactory
    {
        public static GreekWord CreateSingle()
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
