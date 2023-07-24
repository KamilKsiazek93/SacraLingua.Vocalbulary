namespace SacraLingua.Vocalbulary.WebAPI
{
    /// <summary>
    /// Constants value for Web API
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Base API Route
        /// </summary>
        public const string BaseRoute = "api/v{version}";
        public const string ApiVersion = "1";
        /// <summary>
        /// Users Route
        /// </summary>
        public const string UserRoute = $"{BaseRoute}/users/";
    }
}
