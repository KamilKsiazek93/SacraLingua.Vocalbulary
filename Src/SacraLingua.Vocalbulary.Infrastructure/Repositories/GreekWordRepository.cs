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

        public async Task<GreekWord> GetGreekWordByIdAsync(int id)
        {
            return await _dbContext.GreekWords.SingleOrDefaultAsync(x => x.Id == id)
                ?? throw new DomainEntityNotFoundException(typeof(GreekWord).Name, id);
        }
    }
}
