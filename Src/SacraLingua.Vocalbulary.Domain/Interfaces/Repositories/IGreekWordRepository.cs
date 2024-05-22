using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Filters;

namespace SacraLingua.Vocalbulary.Domain.Interfaces.Repositories
{
    public interface IGreekWordRepository
    {
        /// <summary>
        /// Get list of greek words
        /// </summary>
        /// <param name="filter">Filter criteria</param>
        /// <returns>List of greek words</returns>
        Task<PagedResult<GreekWord>> GetGreekWordAsync(GreekWordFilter filter);
        /// <summary>
        /// Add new greek Word
        /// </summary>
        /// <param name="greekWord">Greek Word object with all data filled</param>
        /// <returns>Created Greek Word</returns>
        Task<GreekWord> AddGreekWordAsync(GreekWord greekWord);

        /// <summary>
        /// Get Greek Word when thanks to ID
        /// </summary>
        /// <param name="id">Id of Greek Word</param>
        /// <returns>GreekWordResponse</returns>
        Task<GreekWord> GetGreekWordByIdAsync(int id);
        /// <summary>
        /// Delete Greek Word thanks to Id
        /// </summary>
        /// <param name="greekWordId">Greek Word Identifier</param>
        /// <returns></returns>
        Task<GreekWord> DeleteGreekWordAsync(int greekWordId);
        /// <summary>
        /// Update greek word
        /// </summary>
        /// <param name="id">Greek Word Identifier</param>
        /// <param name="updatedWord">Greek Word Put request</param>
        /// <returns></returns>
        Task<GreekWord> UpdateGreekWordAsync(int id, GreekWord updatedWord);
        /// <summary>
        /// Get Translation of Greek Word thanks to Id
        /// </summary>
        /// <param name="id">Greek Word Identification</param>
        /// <returns>List of translations</returns>
        Task<IList<GreekWordsTranslations>> GetGreekWordTranslation(int id);
    }
}
