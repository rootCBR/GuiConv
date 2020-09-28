using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GuiConv.Source.ValueHandlers
{
    internal class HexHandler : ValueHandler
    {
        // from hex
        public override string Deserialize(string hex)
        {

            if (Utility.IsValidHexString(hex) == true)
            {
                uint r_uint = 0;

                if (uint.TryParse(hex, NumberStyles.AllowHexSpecifier, null, out r_uint))
                {
                    byte[] bytes = BitConverter.GetBytes(r_uint);

                    if (Converter.UseBigEndian == true)
                    {
                        bytes = bytes.Reverse().ToArray();
                    }

                    float r_float = BitConverter.ToSingle(bytes, 0);

                    if (float.TryParse(r_float.ToString(), NumberStyles.Number, null, out r_float))
                    {
                        Console.WriteLine($"Valid hex input (float)");

                        return Convert.ToString(r_float, CultureInfo.InvariantCulture.NumberFormat);
                    }
                }
                else
                {
                    Console.WriteLine($"Valid hex input (string)");

                    string ascii = "";

                    for (int i = 0; i < hex.Length / 2; i++)
                    {
                        string chars = $"{hex[i * 2]}{hex[(i * 2) + 1]}";

                        ascii += (char)Convert.ToUInt32(chars, 16);
                    }

                    return ascii;
                }
            }
            else
            {
                Console.WriteLine("Invalid hex input");
            }

            return "";
        }

        // to hex
        public override string Serialize(string ascii)
        {
            float r_float = 0;

            if (float.TryParse(ascii, NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out r_float))
            {
                Console.WriteLine($"Valid string input (float)");

                uint o_uint = BitConverter.ToUInt32(BitConverter.GetBytes(r_float), 0);

                return $"{o_uint:X}";
            }
            else
            {
                Console.WriteLine($"Valid string input (hex)");

                string hex = "";

                for (int i = 0; i < ascii.Length; i++)
                {
                    hex += $"{Convert.ToInt32(ascii[i]):X}";
                }

                return hex;
            }
        }
    }
}
