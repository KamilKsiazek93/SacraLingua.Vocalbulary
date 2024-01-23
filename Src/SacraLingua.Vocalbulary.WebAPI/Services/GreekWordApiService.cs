using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Filters;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;
using SacraLingua.Vocalbulary.WebAPI.Interfaces;
using SacraLingua.Vocalbulary.WebAPI.Models.Requests;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Services
{
    public class GreekWordApiService : IGreekWordApiService
    {
        private readonly IGreekWordService _greekWordService;
        private readonly IGreekWordLogger _logger;
        private readonly IMapper _mapper;

        public GreekWordApiService(IGreekWordService greekWordService,
            IGreekWordLogger logger,
            IMapper mapper)
        {
            _greekWordService = greekWordService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Add new greek Word
        /// </summary>
        /// <param name="greekWordRequest">Greek Word object with all data filled</param>
        /// <returns>Created Greek Word</returns>
        public async Task<GreekWordResponse> AddGreekWordAsync(GreekWordRequest greekWordRequest)
        {
            try
            {
                GreekWord greekWord = _mapper.Map<GreekWord>(greekWordRequest);
                _logger.LogStartAddGreekWord(greekWord);
                GreekWord greakWordCreated = await _greekWordService.AddGreekWordAsync(greekWord);
                _logger.LogFinishAddGreekWord(greekWordRequest, greakWordCreated);

                return _mapper.Map<GreekWordResponse>(greakWordCreated);
            }
            catch(Exception exception)
            {
                _logger.LogErrorAddGreekWord(greekWordRequest, exception);
                throw;
            }
        }

        /// <summary>
        /// Delete Greek Word thanks to Id
        /// </summary>
        /// <param name="greekWordId">Greek Word Identifier</param>
        /// <returns></returns>
        public async Task<GreekWordResponse> DeleteGreekWordAsync(int greekWordId)
        {
            try
            {
                _logger.LogStartDeleteGreekWord(greekWordId);
                GreekWord greakWordCreated = await _greekWordService.DeleteGreekWordAsync(greekWordId);
                _logger.LogFinishDeleteGreekWord(greekWordId, greakWordCreated);

                return _mapper.Map<GreekWordResponse>(greakWordCreated);
            }
            catch (Exception exception)
            {
                _logger.LogErrorDeleteGreekWord(greekWordId, exception);
                throw;
            }
        }

        /// <summary>
        /// Get List of Greek Word with matching criteria
        /// </summary>
        /// <param name="greekWordFilterRequest"></param>
        /// <returns>List of matching greek words</returns>
        public async Task<PagedResponse<GreekWordResponse>> GetGreekWordAsync(GreekWordFilterRequest greekWordFilterRequest)
        {
            try
            {
                GreekWordFilter filter = _mapper.Map<GreekWordFilter>(greekWordFilterRequest);
                _logger.LogStarGetListOfGreekWord(filter);
                PagedResult<GreekWord> result = await _greekWordService.GetGreekWordAsync(filter);
                _logger.LogFinishGetListOGreekWord(filter, result);

                return new PagedResponse<GreekWordResponse>
                {
                    Items = _mapper.Map<IReadOnlyCollection<GreekWord>, List<GreekWordResponse>>(result.Items),
                    Page = result.Page,
                    PageSize = result.PageSize,
                    NumberOfPages = result.NumberOfPages,
                    TotalItem = result.TotalItems
                };
            }
            catch (Exception exception)
            {
                _logger.LogErrorGetListOGreekWord(greekWordFilterRequest, exception);
                throw;
            }
        }

        /// <summary>
        /// Get Greek Word when thanks to ID
        /// </summary>
        /// <param name="greekWordId">Id of Greek Word</param>
        /// <returns>GreekWordResponse</returns>
        public async Task<GreekWordResponse> GetGreekWordByIdAsync(int greekWordId)
        {
            try
            {
                _logger.LogStartGetGreekWordById(greekWordId);
                GreekWord greekWord = await _greekWordService.GetGreekWordByIdAsync(greekWordId);
                GreekWordResponse response = _mapper.Map<GreekWordResponse>(greekWord);
                _logger.LogFinishGetGreekWordById(greekWordId, greekWord);

                return response;
            }
            catch (Exception exception)
            {
                _logger.LogErrorGetGreekWordById(greekWordId, exception);
                throw;
            }
        }

        /// <summary>
        /// Update greek word
        /// </summary>
        /// <param name="id">Greek Word Identifier</param>
        /// <param name="greekWordRequest">Greek Word Put request</param>
        /// <returns></returns>
        public async Task<GreekWordResponse> UpdateGreekWordAsync(int id, GreekWordUpdateRequest greekWordRequest)
        {
            try
            {
                _logger.LogStartUpdateGreekWord(id);
                GreekWord updatedWord = _mapper.Map<GreekWord>(greekWordRequest);
                GreekWord greekWord = await _greekWordService.UpdateGreekWordAsync(id, updatedWord);
                GreekWordResponse response = _mapper.Map<GreekWordResponse>(greekWord);
                _logger.LogFinishUpdateGreekWord(id, greekWord);

                return response;
            }
            catch (Exception exception)
            {
                _logger.LogErrorUpdateGreekWord(id, exception);
                throw;
            }
        }
    }
}
