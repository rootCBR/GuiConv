using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiConv.Source.ValueHandlers
{
    internal class FNV64Handler_WD1 : ValueHandler
    {
        // from fnv64_wd1
        public override string Deserialize(string i_string)
        {
            return "";
        }

        // to fnv64_wd1
        public override string Serialize(string i_string)
        {
            ulong hash = Hashing.FNV64.Compute(i_string);

            byte[] hashBytes = BitConverter.GetBytes(hash);

            Array.Reverse(hashBytes);

            int hash32 = BitConverter.ToInt32(hashBytes, 4);

            if (Converter.UseBigEndian == true)
            {
                byte[] hash32Bytes = BitConverter.GetBytes(hash32);

                Array.Reverse(hash32Bytes);

                hash32 = BitConverter.ToInt32(hash32Bytes, 0);
            }

            return $"{hash32:X8}";
        }
    }
}