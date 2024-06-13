namespace SacraLingua.Vocalbulary.Domain.Entities
{
    public class BaseTranslationEntity
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Word { get; set; }
        public string Sentence { get; set; }
    }
}
