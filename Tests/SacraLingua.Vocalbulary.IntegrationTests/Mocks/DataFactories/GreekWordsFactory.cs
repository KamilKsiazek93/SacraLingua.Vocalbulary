﻿using SacraLingua.Vocalbulary.Domain.Entities;

namespace SacraLingua.Vocalbulary.IntegrationTests.Mocks.DataFactories
{
    internal static class GreekWordsFactory
    {
        public static GreekWord CreateSingle()
            => new GreekWord(1, "agape", "miłość", "love", "Theos agape estis", "Bóg jest miłością", "God is love");
    }
}