using SacraLingua.Vocalbulary.Domain.Entities;

namespace SacraLingua.Vocalbulary.Domain.Interfaces.Loggers
{
    public interface IGreekWordLogger
    {
        void LogStartGetGreekWordById(object greekWordId);
        void LogFinishGetGreekWordById(object greekWordId, GreekWord greekWord);
        void LogErrorGetGreekWordById(object greekWordId, Exception exception);
    }
}
