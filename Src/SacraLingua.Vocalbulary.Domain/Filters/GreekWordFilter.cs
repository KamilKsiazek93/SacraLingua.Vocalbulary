namespace SacraLingua.Vocalbulary.Domain.Filters
{
    /// <summary>
    /// Greek Word Filter
    /// </summary>
    public class GreekWordFilter
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
        /// <summary>
        /// Page Size
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Page
        /// </summary>
        public int Page { get; set; }
    }
}
