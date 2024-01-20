namespace SacraLingua.Vocalbulary.WebAPI.Models.Requests
{
    /// <summary>
    /// Greek Word Update Request
    /// </summary>
    public class GreekWordUpdateRequest
    {
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
