using Microsoft.EntityFrameworkCore;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Exceptions;
using SacraLingua.Vocalbulary.Domain.Interfaces.Repositories;
using SacraLingua.Vocalbulary.Infrastructure.Database;

namespace SacraLingua.Vocalbulary.Infrastructure.Repositories
{
    public class GreekWordRepository : IGreekWordRepository
    {
        private readonly SacraLinguaDbContext _dbContext;

        public GreekWordRepository(SacraLinguaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Add new greek Word
        /// </summary>
        /// <param name="greekWord">Greek Word object with all data filled</param>
        /// <returns>Created Greek Word</returns>
        public async Task<GreekWord> AddGreekWordAsync(GreekWord greekWord)
        {
            await _dbContext.AddAsync(greekWord);
            await _dbContext.SaveChangesAsync();
            return greekWord;
        }

        /// <summary>
        /// Get Greek Word when thanks to ID
        /// </summary>
        /// <param name="id">Id of Greek Word</param>
        /// <returns>GreekWordResponse</returns>
        public async Task<GreekWord> GetGreekWordByIdAsync(int id)
        {
            GreekWord? greekWord = await _dbContext.GreekWords
                .Include(x => x.Translations)
                .SingleOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            return greekWord
                ?? throw new DomainEntityNotFoundException(typeof(GreekWord).Name, id);
        }
    }
}
