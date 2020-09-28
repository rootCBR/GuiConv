using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiConv.Source.Hashing
{
    public static class FNV64
    {
        public static ulong Compute(string value)
        {
            string str = value.Replace("/", "\\").ToLower();

            return Compute(str, 0xCBF29CE484222325ul);
        }

        public static ulong Compute(string value, ulong seed)
        {
            if (value.Length == 0)
            {
                return 0;
            }

            var hash = seed;
            foreach (char t in value)
            {
                hash *= 0x100000001B3ul;
                hash ^= t;
            }
            return hash;
        }
    }
}
