using Microsoft.Extensions.Logging;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;

namespace SacraLingua.Vocalbulary.Infrastructure.Loggers
{
    public class GreekWordLogger : IGreekWordLogger
    {
        private readonly ILogger<GreekWordLogger> _logger;

        public GreekWordLogger(ILogger<GreekWordLogger> logger)
        {
            _logger = logger;
        }

        public void LogErrorGetGreekWordById(object greekWordId, Exception exception)
            => _logger.LogError($"Error occured during getting greek word by id: {greekWordId}. Application thrown exception: {exception}");

        public void LogFinishGetGreekWordById(object greekWordId, GreekWord greekWord)
            => _logger.LogInformation($"Finish proceeding request for getting greek word by id: {greekWordId}. Result: {greekWord}");

        public void LogStartGetGreekWordById(object greekWordId)
            => _logger.LogInformation($"Start proceeding request for getting greek word by id: {greekWordId}");
    }
}
