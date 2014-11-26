using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseStringKata
{
    class StringReverser
    {
        internal string Reverse(string p)
        {
            if (string.IsNullOrWhiteSpace(p)) return string.Empty;

           var stringCharacters =  p.ToCharArray();
           Array.Reverse(stringCharacters);
           return new String(stringCharacters);
        }
    }
}
