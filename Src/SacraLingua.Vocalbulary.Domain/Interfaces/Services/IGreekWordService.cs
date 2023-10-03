using SacraLingua.Vocalbulary.Domain.Entities;

namespace SacraLingua.Vocalbulary.Domain.Interfaces.Services
{
    public interface IGreekWordService
    {
        /// <summary>
        /// Add new greek Word
        /// </summary>
        /// <param name="greekWord">Greek Word object with all data filled</param>
        /// <returns>Created Greek Word</returns>
        Task<GreekWord> AddGreekWordAsync(GreekWord greekWord);

        /// <summary>
        /// Get Greek Word when thanks to ID
        /// </summary>
        /// <param name="greekWordId">Id of Greek Word</param>
        /// <returns>GreekWordResponse</returns>
        Task<GreekWord> GetGreekWordByIdAsync(int id);
    }
}
