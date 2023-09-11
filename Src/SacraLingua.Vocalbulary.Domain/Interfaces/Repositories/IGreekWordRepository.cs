using SacraLingua.Vocalbulary.Domain.Entities;

namespace SacraLingua.Vocalbulary.Domain.Interfaces.Repositories
{
    public interface IGreekWordRepository
    {
        Task<GreekWord> GetGreekWordByIdAsync(int id);
    }
}
