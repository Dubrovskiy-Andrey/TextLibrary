using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextLibrary.Interfaces;

namespace TextLibrary.Implementations
{
    public class Justifier : IJustifier
    {
        public string Justify(string text, int width)
        {
            if (string.IsNullOrWhiteSpace(text) || width <= 0) return string.Empty;
            var cleaner = new TextCleaner();
            string cleaned = cleaner.RemoveExtraSpaces(text);
            var words = cleaned.Split(' ');
            var lines = new List<string>();
            var current = new List<string>();
            int currentLen = 0;
            foreach (var w in words)
            {
                if (currentLen + w.Length + (current.Count > 0 ? 1 : 0) > width)
                {
                    lines.Add(Distribute(current, width));
                    current.Clear();
                    currentLen = 0;
                }
                current.Add(w);
                currentLen += (current.Count == 1 ? w.Length : w.Length + 1);
            }
            if (current.Count > 0) lines.Add(string.Join(" ", current));
            return string.Join(Environment.NewLine, lines);
        }

        private string Distribute(List<string> words, int width)
        {
            if (words.Count == 0) return string.Empty;
            if (words.Count == 1) return words[0].PadRight(width);
            int totalWordsLen = words.Sum(w => w.Length);
            int totalSpaces = width - totalWordsLen;
            int gaps = words.Count - 1;
            int baseSpace = totalSpaces / gaps;
            int extra = totalSpaces % gaps;
            var sb = new StringBuilder();
            for (int i = 0; i < words.Count; i++)
            {
                sb.Append(words[i]);
                if (i < gaps)
                {
                    int spaces = baseSpace + (i < extra ? 1 : 0);
                    sb.Append(' ', spaces);
                }
            }
            return sb.ToString();
        }
    }
}
