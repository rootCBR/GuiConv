using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiConv.Source.ValueHandlers
{
    internal class CRC32Handler : ValueHandler
    {
        // from crc32
        public override string Deserialize(string i_string)
        {
            return "";
        }

        // to crc32
        public override string Serialize(string i_string)
        {
            uint hash = Hashing.CRC32.Compute(i_string);

            if (Converter.UseBigEndian == true)
            {
                byte[] hashBytes = BitConverter.GetBytes(hash);

                Array.Reverse(hashBytes);

                hash = BitConverter.ToUInt32(hashBytes, 0);
            }

            return $"{hash:X8}";
        }
    }
}
