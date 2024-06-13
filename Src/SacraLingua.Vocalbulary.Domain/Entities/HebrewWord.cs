namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public class HebrewWord : BaseWordEntity<HebrewWord, int, HebrewWordsTranslations>
    {
        public HebrewWord(string word, string sentence, bool isDeleted)
            : base(word, sentence, isDeleted) { }
    }
}
