namespace SacraLingua.Vocalbulary.WebAPI.Models.Responses
{
    /// <summary>
    /// Translation of hebrew word
    /// </summary>
    public class HebrewWordTranslationResponse
    {
        /// <summary>
        /// Destination - to which language is providen translation
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Hebrew Word
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// Sentence in hebrew where hebrew word occur
        /// </summary>
        public string? Sentence { get; set; }
    }
}
