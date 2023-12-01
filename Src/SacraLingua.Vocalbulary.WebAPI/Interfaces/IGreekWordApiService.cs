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
        /// Get Greek Word when thanks to ID
        /// </summary>
        /// <param name="greekWordId">Id of Greek Word</param>
        /// <returns>GreekWordResponse</returns>
        Task<GreekWordResponse> GetGreekWordByIdAsync(int greekWordId);
    }
}
