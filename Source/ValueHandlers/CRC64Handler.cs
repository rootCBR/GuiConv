using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiConv.Source.ValueHandlers
{
    internal class CRC64Handler : ValueHandler
    {
        // from crc64
        public override string Deserialize(string i_string)
        {
            return "";
        }

        // to crc64
        public override string Serialize(string i_string)
        {
            ulong hash = Hashing.CRC64.Compute(i_string);

            if (Converter.UseBigEndian == true)
            {
                byte[] hashBytes = BitConverter.GetBytes(hash);

                Array.Reverse(hashBytes);

                hash = BitConverter.ToUInt64(hashBytes, 0);
            }

            return $"{hash:X16}";
        }
    }
}
