using SacraLingua.Vocalbulary.WebAPI.Interfaces;
using SacraLingua.Vocalbulary.WebAPI.Models.Requests;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Services
{
    public class HebrewWordApiService : IHebrewWordApiService
    {
        public Task<PagedResponse<HebrewWordResponse>> GetHebrewWordAsync(HebrewWordFilterRequest hebrewWordFilterRequest)
        {
            throw new NotImplementedException();
        }
    }
}
