namespace SacraLingua.Vocalbulary.WebAPI.Models.Requests
{
    /// <summary>
    /// Filter criteria for greek word
    /// </summary>
    public class GreekWordFilterRequest : PageRequest
    {
        /// <summary>
        /// Greek Word
        /// </summary>
        public string? Word { get; set; }
        /// <summary>
        /// Translation word
        /// </summary>
        public string? Translation { get; set; }
        /// <summary>
        /// Language of translation
        /// </summary>
        public string? To { get; set; }
    }
}
