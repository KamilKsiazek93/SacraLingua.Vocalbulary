using Microsoft.EntityFrameworkCore;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Filters;
using SacraLingua.Vocalbulary.Domain.Interfaces.Repositories;
using SacraLingua.Vocalbulary.Infrastructure.Database;

namespace SacraLingua.Vocalbulary.Infrastructure.Repositories
{
    public class HebrewWordRepository : IHebrewWordRepository
    {
        private readonly SacraLinguaDbContext _dbContext;

        public HebrewWordRepository(SacraLinguaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<PagedResult<HebrewWord>> GetHebrewWordAsync(HebrewWordFilter filter)
        {
            IQueryable<HebrewWord> hebrewWords =
                _dbContext.HebrewWords
                .Include(x => x.Translations)
                .Where(x => !x.IsDeleted);

            hebrewWords = ApplyFilter(hebrewWords, filter);

            return await GetPagedResultOfHebrewWords(hebrewWords, filter.Page, filter.PageSize);
        }

        private IQueryable<HebrewWord> ApplyFilter(IQueryable<HebrewWord> query, HebrewWordFilter filter)
        {
            if (filter.Word is not null)
                query = query.Where(x => x.Word == filter.Word);
            if (filter.Translation is not null)
                query = query.Where(x => x.Translations.Any(translation => translation.Word == filter.Translation));
            if (filter.To is not null)
                query = query.Where(x => x.Translations.Any(translation => translation.To == filter.To));

            return query;
        }

        private async Task<PagedResult<HebrewWord>> GetPagedResultOfHebrewWords(IQueryable<HebrewWord> query, int page, int pageSize)
            => new PagedResult<HebrewWord>(await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(), query.Count(), pageSize, page);
    }
}
