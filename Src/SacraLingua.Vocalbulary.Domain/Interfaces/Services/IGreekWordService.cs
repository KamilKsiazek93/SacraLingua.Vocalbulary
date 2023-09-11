using SacraLingua.Vocalbulary.Domain.Entities;

namespace SacraLingua.Vocalbulary.Domain.Interfaces.Services
{
    public interface IGreekWordService
    {
        Task<GreekWord> GetGreekWordByIdAsync(int id);
    }
}
