namespace SacraLingua.Vocalbulary.WebAPI.Models.Responses
{
    /// <summary>
    /// List of available translation of greek words
    /// </summary>
    public class GreekWordTranslationListResponse
    {
        /// <summary>
        /// Translations of greek word
        /// </summary>
        public IEnumerable<GreekWordTranslationResponse> Translations  { get; set; }
    }
}
