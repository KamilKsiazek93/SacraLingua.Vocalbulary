namespace SacraLingua.Vocalbulary.WebAPI.Models.Requests
{
    /// <summary>
    /// Page request
    /// </summary>
    public class PageRequest
    {
        /// <summary>
        /// Page Size
        /// </summary>
        public int PageSize { get; set; } = 25;
        /// <summary>
        /// Page
        /// </summary>
        public int Page { get; set; } = 1;
    }
}
