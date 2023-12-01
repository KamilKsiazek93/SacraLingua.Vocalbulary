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

        public static List<GreekWord> CreateMultiple()
            => new List<GreekWord>
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
