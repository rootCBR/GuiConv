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
            hex = Utility.RemoveWhitespace(hex);

            if (Utility.IsValidHexString(hex) == true)
            {
                ushort r_ushort = 0;
                uint r_uint = 0;
                float r_float = 0;
                ulong r_ulong = 0;

                if (Converter.OutputType == Converter.ValueType.Hex)
                {
                    // TO DO: support 8+ byte inputs
                    Console.WriteLine("Valid hex input (hex)");

                    byte[] bytes = new byte[0];

                    int r_int;
                    long r_long;

                    if (int.TryParse(hex, NumberStyles.AllowHexSpecifier, null, out r_int))
                    {
                        bytes = BitConverter.GetBytes(r_int);
                    }
                    else if (long.TryParse(hex, NumberStyles.AllowHexSpecifier, null, out r_long))
                    {
                        bytes = BitConverter.GetBytes(r_long);
                    }

                    if (Converter.UseBigEndian == true)
                    {
                        bytes = bytes.Reverse().ToArray();
                    }

                    string f = BitConverter.ToString(bytes);

                    return BitConverter.ToString(bytes).Replace("-", "");
                }
                else if (Converter.OutputType == Converter.ValueType.String)
                {
                    Console.WriteLine("Valid hex input (ascii)");

                    string ascii = "";

                    for (int i = 0; i < hex.Length / 2; i++)
                    {
                        string chars = $"{hex[i * 2]}{hex[(i * 2) + 1]}";

                        ascii += (char)Convert.ToUInt32(chars, 16);
                    }

                    return ascii;
                }
                else if (Converter.OutputType == Converter.ValueType.Float)
                {
                    Console.WriteLine("Valid hex input (float)");

                    int i = int.Parse(hex, NumberStyles.AllowHexSpecifier);

                    byte[] bytes = BitConverter.GetBytes(i);

                    if (Converter.UseBigEndian == true)
                    {
                        bytes = bytes.Reverse().ToArray();
                    }

                    float f = BitConverter.ToSingle(bytes, 0);

                    return Convert.ToString(f, CultureInfo.InvariantCulture.NumberFormat);
                }
                else if (ushort.TryParse(hex, NumberStyles.AllowHexSpecifier, null, out r_ushort))
                {
                    // 2 bytes

                    Console.WriteLine("Valid hex input (ushort)");

                    byte[] bytes = BitConverter.GetBytes(r_ushort);

                    if (Converter.UseBigEndian == true)
                    {
                        bytes = bytes.Reverse().ToArray();
                    }

                    Console.WriteLine($"Hex input (ushort#{bytes.Length}): {r_ushort}");

                    return BitConverter.ToString(bytes).Replace("-", "");
                }
                else if (uint.TryParse(hex, NumberStyles.AllowHexSpecifier, null, out r_uint))
                {
                    // 4 bytes

                    Console.WriteLine("Valid hex input (uint)");

                    byte[] bytes = BitConverter.GetBytes(r_uint);

                    if (Converter.UseBigEndian == true)
                    {
                        bytes = bytes.Reverse().ToArray();
                    }

                    Console.WriteLine($"Hex input (uint#{bytes.Length}): {r_uint}");

                    return BitConverter.ToString(bytes).Replace("-", "");
                }
                else if (ulong.TryParse(hex, NumberStyles.AllowHexSpecifier, null, out r_ulong))
                {
                    // 8 bytes

                    Console.WriteLine("Valid hex input (ulong)");

                    byte[] bytes = BitConverter.GetBytes(r_ulong);

                    if (Converter.UseBigEndian == true)
                    {
                        bytes = bytes.Reverse().ToArray();
                    }

                    Console.WriteLine($"Hex input (ulong#{bytes.Length}): {r_ulong}");

                    return BitConverter.ToString(bytes).Replace("-", "");
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
            ushort r_ushort = 0;
            uint r_uint = 0;
            ulong r_ulong = 0;
            decimal r_test = 0;

            if (Converter.InputType == Converter.ValueType.Hex)
            {
                return ascii;
            }
            else if (Converter.InputType == Converter.ValueType.Float)
            {
                // float
                if (float.TryParse(ascii, NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out r_float))
                {
                    Console.WriteLine($"Valid string input (float)");

                    byte[] bytes = BitConverter.GetBytes(r_float);

                    if (Converter.UseBigEndian == true)
                    {
                        bytes = bytes.Reverse().ToArray();
                    }

                    uint o_uint = BitConverter.ToUInt32(bytes, 0);

                    return $"{o_uint:X8}";
                }
            }
            else if (Converter.InputType == Converter.ValueType.Int)
            {
                Console.WriteLine("From Int to Hex");

                if (ushort.TryParse(ascii, NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out r_ushort))
                {
                    // int16
                    Console.WriteLine($"Valid string input (short)");

                    string o_string = "";

                    byte[] bytes = BitConverter.GetBytes(r_ushort);

                    if (Converter.UseBigEndian == true)
                    {
                        bytes = bytes.Reverse().ToArray();
                    }

                    long o_short = BitConverter.ToInt16(bytes, 0);

                    int validBytes = 0;

                    for (int b = 0; b < bytes.Length; b++)
                    {
                        if (bytes[b] != 0)
                        {
                            validBytes++;
                        }
                    }

                    if (validBytes == 1)
                    {
                        o_string = $"{o_short:X2}";
                    }
                    else if (validBytes == 2)
                    {
                        o_string = $"{o_short:X4}";
                    }

                    return o_string;
                }
                else if (uint.TryParse(ascii, NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out r_uint))
                {
                    // int32
                    Console.WriteLine($"Valid string input (int)");

                    byte[] bytes = BitConverter.GetBytes(r_uint);

                    if (Converter.UseBigEndian == true)
                    {
                        bytes = bytes.Reverse().ToArray();
                    }

                    int o_int = BitConverter.ToInt32(bytes, 0);

                    return $"{o_int:X8}";
                }
                else if (ulong.TryParse(ascii, NumberStyles.Number, CultureInfo.InvariantCulture.NumberFormat, out r_ulong))
                {
                    // int64
                    Console.WriteLine($"Valid string input (long)");

                    byte[] bytes = BitConverter.GetBytes(r_ulong);

                    if (Converter.UseBigEndian == true)
                    {
                        bytes = bytes.Reverse().ToArray();
                    }

                    ulong o_long = BitConverter.ToUInt64(bytes, 0);

                    return $"{o_long:X16}";
                }
                else
                {
                    Console.WriteLine("Could not recognize Int value");
                }
            }
            else
            {
                // ascii
                Console.WriteLine($"Valid string input (ascii)");

                string hex = "";

                for (int i = 0; i < ascii.Length; i++)
                {
                    hex += $"{Convert.ToInt32(ascii[i]):X}";
                }

                return hex;
            }

            return "";
        }
    }
}
