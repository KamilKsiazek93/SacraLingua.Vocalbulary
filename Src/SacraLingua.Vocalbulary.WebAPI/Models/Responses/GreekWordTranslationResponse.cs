namespace SacraLingua.Vocalbulary.WebAPI.Models.Responses
{
    /// <summary>
    /// Translation of greek word
    /// </summary>
    public class GreekWordTranslationResponse
    {
        /// <summary>
        /// Destination - to which language is providen translation
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Greek Word
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// Sentence in greek where greek word occur
        /// </summary>
        public string? Sentence { get; set; }
    }
}
