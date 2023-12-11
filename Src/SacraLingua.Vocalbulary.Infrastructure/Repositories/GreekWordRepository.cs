using Microsoft.EntityFrameworkCore;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Exceptions;
using SacraLingua.Vocalbulary.Domain.Filters;
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
        /// Delete Greek Word thanks to Id
        /// </summary>
        /// <param name="greekWordId">Greek Word Identifier</param>
        /// <returns></returns>
        public async Task<GreekWord> DeleteGreekWordAsync(int greekWordId)
        {
            GreekWord? greekWord = await _dbContext.GreekWords
               .SingleOrDefaultAsync(x => x.Id == greekWordId && x.IsDeleted == false);

            if(greekWord is null)
                throw new DomainEntityNotFoundException(typeof(GreekWord).Name, greekWordId);

            greekWord.MarkWordAsDeleted(greekWord);

            await _dbContext.SaveChangesAsync();

            return greekWord;
        }

        /// <summary>
        /// Get list of greek words
        /// </summary>
        /// <param name="filter">Filter criteria</param>
        /// <returns>List of greek words</returns>
        public async Task<PagedResult<GreekWord>> GetGreekWordAsync(GreekWordFilter filter)
        {
            IQueryable<GreekWord> greekWords = 
                _dbContext.GreekWords
                .Include(x => x.Translations)
                .Where(x => x.IsDeleted == false);

            greekWords = ApplyFilter(greekWords, filter);

            return GetPagedResultOfGreekWords(greekWords, filter.Page, filter.PageSize);
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

        private IQueryable<GreekWord> ApplyFilter(IQueryable<GreekWord> query, GreekWordFilter filter)
        {
            if(filter.Word is not null)
                query = query.Where(x => x.Word ==  filter.Word);
            if (filter.Translation is not null)
                query = query.Where(x => x.Translations.Any(translation => translation.Word == filter.Translation));
            if (filter.To is not null)
                query = query.Where(x => x.Translations.Any(translation => translation.To == filter.To));

            return query;
        }

        private PagedResult<GreekWord> GetPagedResultOfGreekWords(IQueryable<GreekWord> query, int page, int pageSize)
            => new PagedResult<GreekWord>(query.Skip((page - 1) * pageSize).Take(pageSize).ToList(), query.Count(), pageSize, page);
    }
}
