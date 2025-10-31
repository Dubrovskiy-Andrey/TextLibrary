using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary.Interfaces
{
    public interface ITextProcessingService
    {
        int CountWords(string text);
        string FindLongestWord(string text);
        IDictionary<char, int> CharFrequency(string text);
        string RemoveExtraSpaces(string text);
        string ConvertToUpper(string text);
        string ConvertToLower(string text);
        string JustifyText(string text, int width);
        double GetAverageWordLength(string text);
    }
}
