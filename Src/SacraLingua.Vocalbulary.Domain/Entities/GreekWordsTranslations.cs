namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public class GreekWordsTranslations
    {
        public int Id { get; set; }
        public int GreekWordId { get; set; }
        public string To { get; set; }
        public string Word { get; set; }
        public string Sentence { get; set; }
    }
}
