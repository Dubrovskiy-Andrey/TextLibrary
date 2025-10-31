using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextLibrary.Interfaces;

namespace TextLibrary.Implementations
{
    public class WordStatistics : IWordStatistics
    {
        public double GetAverageWordLength(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            // Разбиваем по пробелам и знакам пунктуации
            var words = text
                .Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '-', '\n', '\r', '\t' },
                       StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
                return 0;

            double totalLength = words.Sum(w => w.Length);
            return totalLength / words.Length;
        }
    }
}
