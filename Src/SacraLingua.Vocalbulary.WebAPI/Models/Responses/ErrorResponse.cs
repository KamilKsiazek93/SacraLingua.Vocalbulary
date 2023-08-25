namespace SacraLingua.Vocalbulary.WebAPI.Models.Responses
{
    public class ErrorResponse
    {
        /// <summary>
        /// HTTP Status Code
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Error Message
        /// </summary>
        public string Message { get; set; }
    }
}
