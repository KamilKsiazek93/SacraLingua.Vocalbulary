namespace SacraLingua.Vocalbulary.WebAPI.Models.Responses
{
    public class GreekWordResponse
    {
        /// <summary>
        /// Id of word
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Greek Word
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// Translation from greek word to polish
        /// </summary>
        public string WordPolishTranslation { get; set; }
        /// <summary>
        /// Translation from greek word to english
        /// </summary>
        public string WordEnglishTranslation { get; set; }
        /// <summary>
        /// Sentence in greek where greek word occur
        /// </summary>
        public string? Sentence { get; set; }
        /// <summary>
        /// Translation from greek sentence word to polish
        /// </summary>
        public string? SentencePolishTranslation { get; set; }
        /// <summary>
        /// Translation from greek sentence word to english
        /// </summary>
        public string? SentenceEnglishTranslation { get; set; }
    }
}
