using SacraLingua.Vocalbulary.Domain.Entities;

namespace SacraLingua.Vocalbulary.Domain.Interfaces.Loggers
{
    public interface IGreekWordLogger
    {
        void LogStartGetGreekWordById(object greekWordId);
        void LogFinishGetGreekWordById(object greekWordId, GreekWord greekWord);
        void LogErrorGetGreekWordById(object greekWordId, Exception exception);

        void LogStartAddGreekWord(object greekWordRequest);
        void LogFinishAddGreekWord(object greekWordRequest, GreekWord greekWord);
        void LogErrorAddGreekWord(object greekWordRequest, Exception exception);

        void LogStarGetListOfGreekWord(object greekWordRequest);
        void LogFinishGetListOGreekWord(object greekWordRequest, PagedResult<GreekWord> greekWord);
        void LogErrorGetListOGreekWord(object greekWordRequest, Exception exception);

        void LogStartDeleteGreekWord(object greekWordRequest);
        void LogFinishDeleteGreekWord(object greekWordRequest, GreekWord greekWord);
        void LogErrorDeleteGreekWord(object greekWordRequest, Exception exception);

        void LogStartUpdateGreekWord(object greekWordRequest);
        void LogFinishUpdateGreekWord(object greekWordRequest, GreekWord greekWord);
        void LogErrorUpdateGreekWord(object greekWordRequest, Exception exception);
    }
}
