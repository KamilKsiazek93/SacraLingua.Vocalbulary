namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public class GreekWord : BaseEntity<GreekWord, int>
    {
        public string Word { get; }
        public string WordPolishTranslation { get; }
        public string WordEnglishTranslation { get; }
        public string Sentence { get; }
        public string SentencePolishTranslation { get; }
        public string SentenceEnglishTranslation { get; }

        public GreekWord(
            string word,
            string wordPolishTranslation,
            string wordEnglishTranslation,
            string sentence,
            string sentencePolishTranslation,
            string sentenceEnglishTranslation)
        {
            Word = word;
            WordPolishTranslation = wordPolishTranslation;
            WordEnglishTranslation = wordEnglishTranslation;
            Sentence = sentence;
            SentencePolishTranslation = sentencePolishTranslation;
            SentenceEnglishTranslation = sentenceEnglishTranslation;
        }
    }
}
