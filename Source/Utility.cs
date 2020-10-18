using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GuiConv.Source
{
    public static class Utility
    {
        public static bool IsValidHexString(string hex)
        {
            return Regex.IsMatch(hex, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        public static string RemoveWhitespace(string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }
    }
}
