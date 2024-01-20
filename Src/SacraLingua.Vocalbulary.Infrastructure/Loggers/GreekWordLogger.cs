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

        public void LogErrorAddGreekWord(object greekWordRequest, Exception exception)
            => _logger.LogError($"Error occured during adding greek word with passed object: {JsonSerializer.Serialize(greekWordRequest)}. Application thrown exception: {exception}");

        public void LogStartAddGreekWord(object greekWordRequest)
            => _logger.LogInformation($"Start proceeding request for adding greek word with passed object: {JsonSerializer.Serialize(greekWordRequest)}");

        public void LogFinishAddGreekWord(object greekWordRequest, GreekWord greekWord)
            => _logger.LogInformation($"Finish proceeding request for adding greek word with passed object: {JsonSerializer.Serialize(greekWordRequest)}. Result: {JsonSerializer.Serialize(greekWord, _options)}");

        public void LogStarGetListOfGreekWord(object greekWordRequest)
            => _logger.LogInformation($"Start proceeding request for getting list of greek words: {JsonSerializer.Serialize(greekWordRequest)}");

        public void LogFinishGetListOGreekWord(object greekWordRequest, PagedResult<GreekWord> greekWord)
            => _logger.LogInformation($"Finish proceeding request for getting list of greek words: {JsonSerializer.Serialize(greekWord)}");
        public void LogErrorGetListOGreekWord(object greekWordRequest, Exception exception)
            => _logger.LogError($"Error occured during getting list of greek words. Filter: {JsonSerializer.Serialize(greekWordRequest)}. Application thrown exception: {exception}");

        public void LogStartDeleteGreekWord(object greekWordId)
            => _logger.LogInformation($"Start proceeding request for delete greek word by id: {greekWordId}");

        public void LogFinishDeleteGreekWord(object greekWordId, GreekWord greekWord)
            => _logger.LogInformation($"Finish proceeding request for getting greek word by id: {greekWordId}. Deleted word: {JsonSerializer.Serialize(greekWord)}");

        public void LogErrorDeleteGreekWord(object greekWordId, Exception exception)
            => _logger.LogError($"Error occured during delete greek word by id: {greekWordId}. Application thrown exception: {exception}");

        public void LogStartUpdateGreekWord(object greekWordRequest)
            => _logger.LogInformation($"Start proceeding request for update greek word with new body: {JsonSerializer.Serialize(greekWordRequest)}");

        public void LogFinishUpdateGreekWord(object greekWordRequest, GreekWord greekWord)
             => _logger.LogInformation($"Finish proceeding request for update greek word with new body: {JsonSerializer.Serialize(greekWordRequest)}. Updated word: {JsonSerializer.Serialize(greekWord)}");

        public void LogErrorUpdateGreekWord(object greekWordRequest, Exception exception)
            => _logger.LogError($"Error occured during update greek word with new body: {JsonSerializer.Serialize(greekWordRequest)}. Application thrown exception: {exception}");

    }
}
