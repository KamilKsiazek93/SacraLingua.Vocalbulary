using Microsoft.Extensions.Logging;
using SacraLingua.Vocalbulary.Domain.Entities;
using SacraLingua.Vocalbulary.Domain.Interfaces.Loggers;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SacraLingua.Vocalbulary.Infrastructure.Loggers
{
    public class HebrewWordLogger : IHebrewWordLogger
    {
        private readonly ILogger<HebrewWordLogger> _logger;
        private readonly JsonSerializerOptions _options;

        public HebrewWordLogger(ILogger<HebrewWordLogger> logger)
        {
            _logger = logger;
            _options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
        }

        public void LogErrorGetListOHebrewWord(object hebrewWordRequest, Exception exception)
            => _logger.LogError($"Error occured during getting list of greek words. Filter: {JsonSerializer.Serialize(hebrewWordRequest)}. Application thrown exception: {exception}");

        public void LogFinishGetListOHebrewWord(object hebrewWordRequest, PagedResult<HebrewWord> hebrewWord)
             => _logger.LogInformation($"Finish proceeding request for getting list of hebrew words: {JsonSerializer.Serialize(hebrewWord)}");


        public void LogStarGetListOfHebrewWord(object hebrewWordRequest)
             => _logger.LogInformation($"Start proceeding request for getting list of hebrew words: {JsonSerializer.Serialize(hebrewWordRequest)}");
    }
}
