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
        /// <summary>
        /// Api version
        /// </summary>
        public const string ApiVersion = "1";
        /// <summary>
        /// Users Route
        /// </summary>
        public const string UserRoute = $"{BaseRoute}/users/";
        /// <summary>
        /// GreekWords Route
        /// </summary>
        public const string GreekWordsRoute = $"{BaseRoute}/greek-words/";
        /// <summary>
        /// Bearer schema authentication
        /// </summary>
        public const string BearerSchemaAuthentication = "Bearer";
    }
}
