namespace SacraLingua.Vocalbulary.WebAPI.Models.Responses
{
    /// <summary>
    /// Hebrew Word Response
    /// </summary>
    public class HebrewWordResponse
    {
        /// <summary>
        /// Id of word
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Hebrew Word
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// Sentence in hebrew where hebrew word occur
        /// </summary>
        public string? Sentence { get; set; }
        /// <summary>
        /// List of available translations
        /// </summary>
        public IEnumerable<HebrewWordTranslationResponse> Translations { get; set; }
    }
}
