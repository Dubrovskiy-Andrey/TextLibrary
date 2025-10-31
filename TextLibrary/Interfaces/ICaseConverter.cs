using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary.Interfaces
{
    public interface ICaseConverter
    {
        string ToUpper(string text);
        string ToLower(string text);
    }
}
