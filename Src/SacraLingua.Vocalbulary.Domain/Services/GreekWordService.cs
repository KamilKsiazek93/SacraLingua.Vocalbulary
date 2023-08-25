using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Exceptions;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using SacraLingua.Vocalbulary.Domain.Interfaces.Repositories;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;

namespace SacraLingua.Vocalbulary.Domain.Services
{
    public class GreekWordService : IGreekWordService
    {
        private readonly IGreekWordRepository _greekWordRepository;
        private readonly IGreekWordLogger _logger;

        public GreekWordService(IGreekWordRepository greekWordRepository,
            IGreekWordLogger logger)
        {
            _greekWordRepository = greekWordRepository;
            _logger = logger;
        }

        public async Task<GreekWord> GetGreekWordByIdAsync(int id)
        {
            VerifyId(id);

            try
            {
                return await _greekWordRepository.GetGreekWordByIdAsync(id);
            }
            catch (Exception exception)
            {
                _logger.LogErrorGetGreekWordById(id, exception);
                throw;
            }
        }

        private void VerifyId(int id)
        {
            if (id <= 0)
                throw new DomainInvalidIdException(id);
        }
    }
}
