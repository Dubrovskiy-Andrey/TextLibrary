using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextLibrary.Interfaces;

namespace TextLibrary.Implementations
{
    public class WordCounter : IWordCounter
    {
        public int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;
            char[] sep = new char[] { ' ', '\t', '\r', '\n', '.', ',', ';', ':', '!', '?', '-', '—', '\"', '\'' };
            return text.Split(sep, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
