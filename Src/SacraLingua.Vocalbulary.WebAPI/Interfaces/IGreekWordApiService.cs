using SacraLingua.Vocalbulary.WebAPI.Models.Requests;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Interfaces
{
    public interface IGreekWordApiService
    {
        /// <summary>
        /// Get List of Greek Word with matching criteria
        /// </summary>
        /// <param name="greekWordFilterRequest"></param>
        /// <returns>List of matching greek words</returns>
        Task<PagedResponse<GreekWordResponse>> GetGreekWordAsync(GreekWordFilterRequest greekWordFilterRequest);
        /// <summary>
        /// Add new greek Word
        /// </summary>
        /// <param name="greekWord">Greek Word object with all data filled</param>
        /// <returns>Created Greek Word</returns>
        Task<GreekWordResponse> AddGreekWordAsync(GreekWordRequest greekWord);

        /// <summary>
        /// Get Greek Word thanks to ID
        /// </summary>
        /// <param name="greekWordId">Id of Greek Word</param>
        /// <returns>GreekWordResponse</returns>
        Task<GreekWordResponse> GetGreekWordByIdAsync(int greekWordId);

        /// <summary>
        /// Delete Greek Word thanks to Id
        /// </summary>
        /// <param name="greekWordId">Greek Word Identifier</param>
        /// <returns></returns>
        Task<GreekWordResponse> DeleteGreekWordAsync(int greekWordId);
        /// <summary>
        /// Update greek word
        /// </summary>
        /// <param name="id">Greek Word Identifier</param>
        /// <param name="greekWordRequest">Greek Word Put request</param>
        /// <returns></returns>
        Task<GreekWordResponse> UpdateGreekWordAsync(int id, GreekWordUpdateRequest greekWordRequest);

        /// <summary>
        /// Get Translation of Greek Word thanks to Id
        /// </summary>
        /// <param name="id">Greek Word Identification</param>
        /// <returns>List of translations</returns>
        Task<GreekWordTranslationListResponse> GetGreekWordTranslation(int id);
    }
}
