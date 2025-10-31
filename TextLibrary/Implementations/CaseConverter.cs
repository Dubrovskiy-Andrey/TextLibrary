using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextLibrary.Interfaces;

namespace TextLibrary.Implementations
{
    public class CaseConverter : ICaseConverter
    {
        public string ToUpper(string text) => text ?? string.Empty;
        public string ToLower(string text) => text ?? string.Empty;
    }
}
