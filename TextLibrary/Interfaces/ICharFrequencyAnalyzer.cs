using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary.Interfaces
{
    public interface ICharFrequencyAnalyzer
    {
        IDictionary<char, int> AnalyzeFrequency(string text);
    }
}
