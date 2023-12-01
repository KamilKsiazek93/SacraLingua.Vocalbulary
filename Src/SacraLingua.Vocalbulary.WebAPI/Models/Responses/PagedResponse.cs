namespace SacraLingua.Vocalbulary.WebAPI.Models.Responses
{
    /// <summary>
    /// Paged response with list of items
    /// </summary>
    /// <typeparam name="T">Type of object in retrieving list</typeparam>
    public class PagedResponse<T>
    {
        /// <summary>
        /// Amount of total matching items
        /// </summary>
        public int TotalItem { get; set; }
        /// <summary>
        /// Page Size
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// Page
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// Number of all pages with current criteria
        /// </summary>
        public int NumberOfPages { get; set; }
        /// <summary>
        /// List of matching objects
        /// </summary>
        public IEnumerable<T> Items { get; set; }
    }
}
