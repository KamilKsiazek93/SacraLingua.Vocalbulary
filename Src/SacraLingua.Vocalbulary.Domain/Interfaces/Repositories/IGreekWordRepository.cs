using SacraLingua.Vocalbulary.Domain.Entities;

namespace SacraLingua.Vocalbulary.Domain.Interfaces.Repositories
{
    public interface IGreekWordRepository
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
        /// <param name="id">Id of Greek Word</param>
        /// <returns>GreekWordResponse</returns>
        Task<GreekWord> GetGreekWordByIdAsync(int id);
    }
}
