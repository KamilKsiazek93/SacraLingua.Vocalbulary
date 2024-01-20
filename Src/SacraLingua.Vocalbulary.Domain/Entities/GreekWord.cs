
namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public class GreekWord : BaseEntity<GreekWord, int>
    {
        public string Word { get; private set; }
        public string Sentence { get; private set; }
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

        public void SetGreekWord(string word)
        {
            Word = word;
        }

        public void SetGreekWordSentence(string sentence)
        {
            Sentence = sentence;
        }
    }
}
