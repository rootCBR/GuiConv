using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiConv.Source.ValueHandlers
{
    internal class CRC32Handler_R : ValueHandler
    {
        // from crc32_r
        public override string Deserialize(string i_string)
        {
            return "";
        }

        // to crc32_r
        public override string Serialize(string i_string)
        {
            uint hash = Hashing.CRC32.Compute(i_string);

            byte[] hashBytes = BitConverter.GetBytes(hash);

            Array.Reverse(hashBytes);

            return $"{BitConverter.ToInt32(hashBytes, 0):X8}";
        }
    }
}