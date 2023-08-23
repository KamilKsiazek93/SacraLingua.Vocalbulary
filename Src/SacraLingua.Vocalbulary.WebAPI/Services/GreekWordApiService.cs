using AutoMapper;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;
using SacraLingua.Vocalbulary.WebAPI.Interfaces;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Services
{
    public class GreekWordApiService : IGreekWordApiService
    {
        private readonly IGreekWordService _greekWordService;
        private readonly IMapper _mapper;

        public GreekWordApiService(IGreekWordService greekWordService, IMapper mapper)
        {
            _greekWordService = greekWordService;
            _mapper = mapper;
        }

        public async Task<GreekWordResponse> GetGreekWordByIdAsync(int greekWordId)
        {
            GreekWord greekWord = await _greekWordService.GetGreekWordByIdAsync(greekWordId);

            return _mapper.Map<GreekWordResponse>(greekWord);
        }
    }
}
