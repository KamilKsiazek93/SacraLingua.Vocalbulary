﻿namespace SacraLingua.Vocalbulary.WebAPI.Models.Responses
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
        /// Sentence in greek where greek word occur
        /// </summary>
        public string? Sentence { get; set; }
        /// <summary>
        /// List of available translations
        /// </summary>
        public IEnumerable<GreekWordTranslationResponse> Translations { get; set; }
    }
}
