using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Exceptions;
using SacraLingua.Vocalbulary.Domain.Filters;
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
        /// Delete Greek Word thanks to Id
        /// </summary>
        /// <param name="greekWordId">Greek Word Identifier</param>
        /// <returns></returns>
        public async Task<GreekWord> DeleteGreekWordAsync(int greekWordId)
        {
            VerifyId(greekWordId);

            try
            {
                return await _greekWordRepository.DeleteGreekWordAsync(greekWordId);
            }
            catch (Exception exception)
            {
                _logger.LogErrorDeleteGreekWord(greekWordId, exception);
                throw;
            }
        }

        /// <summary>
        /// Get List of Greek Word with filter criteria
        /// </summary>
        /// <param name="filter">Greek Word Filter</param>
        /// <returns>Matching greek words</returns>
        public async Task<PagedResult<GreekWord>> GetGreekWordAsync(GreekWordFilter filter)
        {
            try
            {
                return await _greekWordRepository.GetGreekWordAsync(filter);
            }
            catch (Exception exception)
            {
                _logger.LogErrorGetListOGreekWord(filter, exception);
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

        /// <summary>
        /// Get Translation of Greek Word thanks to Id
        /// </summary>
        /// <param name="id">Greek Word Identification</param>
        /// <returns>List of translations</returns>
        public async Task<IList<GreekWordsTranslations>> GetGreekWordTranslation(int id)
        {
            VerifyId(id);

            try
            {
                return await _greekWordRepository.GetGreekWordTranslation(id);
            }
            catch (Exception exception)
            {
                _logger.LogErrorGetGreekWordTranslation(id, exception);
                throw;
            }
        }

        /// <summary>
        /// Update greek word
        /// </summary>
        /// <param name="id">Greek Word Identifier</param>
        /// <param name="updatedWord">Greek Word Put request</param>
        /// <returns></returns>
        public async Task<GreekWord> UpdateGreekWordAsync(int id, GreekWord updatedWord)
        {
            VerifyId(id);

            try
            {
                return await _greekWordRepository.UpdateGreekWordAsync(id, updatedWord);
            }
            catch (Exception exception)
            {
                _logger.LogErrorUpdateGreekWord(id, exception);
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
