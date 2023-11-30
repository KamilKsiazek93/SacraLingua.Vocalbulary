namespace SacraLingua.Vocalbulary.WebAPI.Models.Requests
{
    public class GreekWordRequest
    {
        /// <summary>
        /// Greek Word
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// Sentence in greek where greek word occur
        /// </summary>
        public string? Sentence { get; set; }
        /// <summary>
        /// List of translations
        /// </summary>
        public IEnumerable<GreekWordTranslationRequest> Translations { get; set; }
    }
}
