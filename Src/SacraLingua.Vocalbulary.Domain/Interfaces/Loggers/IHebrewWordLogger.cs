using SacraLingua.Vocalbulary.Domain.Entities;

namespace SacraLingua.Vocalbulary.Domain.Interfaces.Loggers
{
    public interface IHebrewWordLogger
    {
        void LogStarGetListOfHebrewWord(object hebrewWordRequest);
        void LogFinishGetListOHebrewWord(object hebrewWordRequest, PagedResult<HebrewWord> hebrewWord);
        void LogErrorGetListOHebrewWord(object hebrewWordRequest, Exception exception);
    }
}
