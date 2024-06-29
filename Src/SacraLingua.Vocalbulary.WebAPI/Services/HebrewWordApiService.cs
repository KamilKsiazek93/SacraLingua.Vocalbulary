using AutoMapper;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Filters;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;
using SacraLingua.Vocalbulary.Domain.Services;
using SacraLingua.Vocalbulary.WebAPI.Interfaces;
using SacraLingua.Vocalbulary.WebAPI.Models.Requests;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Services
{
    public class HebrewWordApiService : IHebrewWordApiService
    {
        private readonly IHebrewWordService _hebrewWordService;
        private readonly IHebrewWordLogger _logger;
        private readonly IMapper _mapper;

        public HebrewWordApiService(IHebrewWordService hebrewWordService,
            IHebrewWordLogger logger, 
            IMapper mapper)
        {
            _hebrewWordService = hebrewWordService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<PagedResponse<HebrewWordResponse>> GetHebrewWordAsync(HebrewWordFilterRequest hebrewWordFilterRequest)
        {
            try
            {
                HebrewWordFilter filter = _mapper.Map<HebrewWordFilter>(hebrewWordFilterRequest);
                _logger.LogStarGetListOfHebrewWord(filter);
                PagedResult<HebrewWord> result = await _hebrewWordService.GetHebrewWordAsync(filter);
                _logger.LogFinishGetListOHebrewWord(filter, result);

                return new PagedResponse<HebrewWordResponse>
                {
                    Items = _mapper.Map<IReadOnlyCollection<HebrewWord>, List<HebrewWordResponse>>(result.Items),
                    Page = result.Page,
                    PageSize = result.PageSize,
                    NumberOfPages = result.NumberOfPages,
                    TotalItem = result.TotalItems
                };
            }
            catch (Exception exception)
            {
                _logger.LogErrorGetListOHebrewWord(hebrewWordFilterRequest, exception);
                throw;
            }
        }
    }
}
