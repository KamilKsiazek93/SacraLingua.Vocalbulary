using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Interfaces.Repositories;
using SacraLingua.Vocalbulary.Domain.Interfaces.Services;

namespace SacraLingua.Vocalbulary.Domain.Services
{
    public class GreekWordService : IGreekWordService
    {
        private readonly IGreekWordRepository _greekWordRepository;

        public GreekWordService(IGreekWordRepository greekWordRepository)
        {
            _greekWordRepository = greekWordRepository;
        }

        public async Task<GreekWord> GetGreekWordByIdAsync(int id)
        {
            return await _greekWordRepository.GetGreekWordByIdAsync(id);
        }
    }
}
