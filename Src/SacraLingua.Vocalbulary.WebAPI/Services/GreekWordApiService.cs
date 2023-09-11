using AutoMapper;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;
using SacraLingua.Vocalbulary.WebAPI.Interfaces;
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
    }
}
