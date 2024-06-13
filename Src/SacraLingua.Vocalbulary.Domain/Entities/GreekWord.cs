
namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public class GreekWord : BaseWordEntity<GreekWord, int, GreekWordsTranslations>
    {
        public GreekWord(string word, string sentence, bool isDeleted)
            : base(word, sentence, isDeleted) { }
    }
}
