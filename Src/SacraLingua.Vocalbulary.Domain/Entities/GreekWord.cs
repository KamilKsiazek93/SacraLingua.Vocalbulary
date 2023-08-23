namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public class GreekWord
    {
        public int Id { get; }
        public string Word { get; }
        public string WordPolishTranslation { get; }
        public string WordEnglishTranslation { get; }
        public string Sentence { get; }
        public string SentencePolishTranslation { get; }
        public string SentenceEnglishTranslation { get; }

        protected GreekWord() { }

        public GreekWord(int id, 
            string word, 
            string wordPolishTranslation, 
            string wordEnglishTranslation, 
            string sentence, 
            string sentencePolishTranslation, 
            string sentenceEnglishTranslation)
        {
            Id = id;
            Word = word;
            WordPolishTranslation = wordPolishTranslation;
            WordEnglishTranslation = wordEnglishTranslation;
            Sentence = sentence;
            SentencePolishTranslation = sentencePolishTranslation;
            SentenceEnglishTranslation = sentenceEnglishTranslation;
        }
    }
}
