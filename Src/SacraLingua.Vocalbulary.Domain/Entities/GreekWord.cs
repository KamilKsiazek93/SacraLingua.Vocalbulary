namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public class GreekWord : BaseEntity<GreekWord, int>
    {
        public string Word { get; }
        public string Sentence { get; }
        public bool IsDeleted { get; private set; }
        public IEnumerable<GreekWordsTranslations> Translations { get; set; }

        public GreekWord(
            string word,
            string sentence,
            bool isDeleted)
        {
            Word = word;
            Sentence = sentence;
            IsDeleted = isDeleted;
        }

        public void MarkWordAsDeleted(GreekWord greekWord)
        {
            greekWord.IsDeleted = true;
        }
    }
}
