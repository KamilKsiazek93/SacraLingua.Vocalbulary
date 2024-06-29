using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Filters;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using SacraLingua.Vocalbulary.Domain.Interfaces.Repositories;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacraLingua.Vocalbulary.Domain.Services
{
    public class HebrewWordService : IHebrewWordService
    {
        private readonly IHebrewWordRepository _hebrewWordRepository;
        private readonly IHebrewWordLogger _logger;

        public HebrewWordService(IHebrewWordRepository hebrewWordRepository, 
            IHebrewWordLogger logger)
        {
            _hebrewWordRepository = hebrewWordRepository;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<PagedResult<HebrewWord>> GetHebrewWordAsync(HebrewWordFilter filter)
        {
            try
            {
                return await _hebrewWordRepository.GetHebrewWordAsync(filter);
            }
            catch (Exception exception)
            {
                _logger.LogErrorGetListOHebrewWord(filter, exception);
                throw;
            }
        }
    }
}
