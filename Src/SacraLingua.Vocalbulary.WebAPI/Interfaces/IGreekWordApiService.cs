using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Interfaces
{
    public interface IGreekWordApiService
    {
        /// <summary>
        /// Get Greek Word when thanks to ID
        /// </summary>
        /// <param name="greekWordId">Id of Greek Word</param>
        /// <returns>GreekWordResponse</returns>
        Task<GreekWordResponse> GetGreekWordByIdAsync(int greekWordId);
    }
}
