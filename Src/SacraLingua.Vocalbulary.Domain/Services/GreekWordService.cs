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

        /// <summary>
        /// Add new greek Word
        /// </summary>
        /// <param name="greekWord">Greek Word object with all data filled</param>
        /// <returns>Created Greek Word</returns>
        public async Task<GreekWord> AddGreekWordAsync(GreekWord greekWord)
        {
            try
            {
                return await _greekWordRepository.AddGreekWordAsync(greekWord);
            }
            catch(Exception exception)
            {
                _logger.LogErrorAddGreekWord(greekWord, exception);
                throw;
            }
        }

        /// <summary>
        /// Get Greek Word when thanks to ID
        /// </summary>
        /// <param name="id">Id of Greek Word</param>
        /// <returns>GreekWordResponse</returns>
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
