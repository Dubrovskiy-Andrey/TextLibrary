using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextLibrary.Interfaces;

namespace TextLibrary.Implementations
{
    public class CharFrequencyAnalyzer : ICharFrequencyAnalyzer
    {
        public IDictionary<char, int> AnalyzeFrequency(string text)
        {
            var dict = new Dictionary<char, int>();
            if (string.IsNullOrEmpty(text)) return dict;
            foreach (var ch in text)
            {
                if (dict.ContainsKey(ch)) dict[ch]++; else dict[ch] = 1;
            }
            return dict;
        }
    }
}
