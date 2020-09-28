using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiConv.Source.ValueHandlers
{
    internal class CRC64Handler_R : ValueHandler
    {
        // from crc64_r
        public override string Deserialize(string i_string)
        {
            return "";
        }

        // to crc64_r
        public override string Serialize(string i_string)
        {
            ulong hash = Hashing.CRC64.Compute(i_string);

            byte[] hashBytes = BitConverter.GetBytes(hash);

            Array.Reverse(hashBytes);

            return $"{BitConverter.ToInt64(hashBytes, 0):X16}";
        }
    }
}