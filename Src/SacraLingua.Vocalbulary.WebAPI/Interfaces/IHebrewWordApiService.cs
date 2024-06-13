using SacraLingua.Vocalbulary.WebAPI.Models.Requests;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Interfaces
{
    public interface IHebrewWordApiService
    {
        /// <summary>
        /// Get List of Greek Word with matching criteria
        /// </summary>
        /// <param name="hebrewWordFilterRequest"></param>
        /// <returns>List of matching greek words</returns>
        Task<PagedResponse<HebrewWordResponse>> GetHebrewWordAsync(HebrewWordFilterRequest hebrewWordFilterRequest);
    }
}
