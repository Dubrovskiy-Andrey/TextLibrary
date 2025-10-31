using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextLibrary.Interfaces;

namespace TextLibrary.Services
{
    public class TextProcessingService : ITextProcessingService
    {
        private readonly IWordCounter _wordCounter;
        private readonly ILongestWordFinder _longestFinder;
        private readonly ICharFrequencyAnalyzer _charAnalyzer;
        private readonly ITextCleaner _cleaner;
        private readonly ICaseConverter _caseConverter;
        private readonly IJustifier _justifier;

        public TextProcessingService(
            IWordCounter wordCounter,
            ILongestWordFinder longestFinder,
            ICharFrequencyAnalyzer charAnalyzer,
            ITextCleaner cleaner,
            ICaseConverter caseConverter,
            IJustifier justifier)
        {
            _wordCounter = wordCounter;
            _longestFinder = longestFinder;
            _charAnalyzer = charAnalyzer;
            _cleaner = cleaner;
            _caseConverter = caseConverter;
            _justifier = justifier;
        }

        public int CountWords(string text) => _wordCounter.CountWords(text);
        public string FindLongestWord(string text) => _longestFinder.FindLongest(text);
        public IDictionary<char, int> CharFrequency(string text) => _charAnalyzer.AnalyzeFrequency(text);
        public string RemoveExtraSpaces(string text) => _cleaner.RemoveExtraSpaces(text);
        public string ConvertToUpper(string text) => _caseConverter.ToUpper(text);
        public string ConvertToLower(string text) => _caseConverter.ToLower(text);
        public string JustifyText(string text, int width) => _justifier.Justify(text, width);
    }
}
