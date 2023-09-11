using Microsoft.Extensions.Logging;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SacraLingua.Vocalbulary.Infrastructure.Loggers
{
    public class GreekWordLogger : IGreekWordLogger
    {
        private readonly ILogger<GreekWordLogger> _logger;
        private readonly JsonSerializerOptions _options;

        public GreekWordLogger(ILogger<GreekWordLogger> logger)
        {
            _logger = logger;
            _options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
        }

        public void LogErrorGetGreekWordById(object greekWordId, Exception exception)
            => _logger.LogError($"Error occured during getting greek word by id: {greekWordId}. Application thrown exception: {exception}");

        public void LogFinishGetGreekWordById(object greekWordId, GreekWord greekWord)
            => _logger.LogInformation($"Finish proceeding request for getting greek word by id: {greekWordId}. Result: {JsonSerializer.Serialize(greekWord, _options)}");

        public void LogStartGetGreekWordById(object greekWordId)
            => _logger.LogInformation($"Start proceeding request for getting greek word by id: {greekWordId}");
    }
}
