namespace SacraLingua.Vocalbulary.WebAPI.Models.Requests
{
    /// <summary>
    /// Greek Word Translation
    /// </summary>
    public class GreekWordTranslationRequest
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
