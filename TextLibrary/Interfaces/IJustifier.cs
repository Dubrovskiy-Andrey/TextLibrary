using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary.Interfaces
{
    public interface IJustifier
    {
        string Justify(string text, int width);
    }
}
