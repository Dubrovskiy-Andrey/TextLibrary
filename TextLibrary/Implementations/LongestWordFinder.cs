using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextLibrary.Interfaces;

namespace TextLibrary.Implementations
{
    public class LongestWordFinder : ILongestWordFinder
    {
        public string FindLongest(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            char[] sep = new char[] { ' ', '\t', '\r', '\n', '.', ',', ';', ':', '!', '?', '-', '—', '\"', '\'' };
            var words = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0) return string.Empty;
            return words.OrderByDescending(w => w.Length).ThenBy(w => w).First();
        }
    }
}
