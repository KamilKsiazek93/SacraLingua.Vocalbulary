using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Filters;

namespace SacraLingua.Vocalbulary.Domain.Interfaces.Repositories
{
    public interface IHebrewWordRepository
    {
        /// <summary>
        /// Get List of Hebrew Word with filter criteria
        /// </summary>
        /// <param name="filter">Hebrew Word Filter</param>
        /// <returns>Matching Hebrew words</returns>
        Task<PagedResult<HebrewWord>> GetHebrewWordAsync(HebrewWordFilter filter);
    }
}
