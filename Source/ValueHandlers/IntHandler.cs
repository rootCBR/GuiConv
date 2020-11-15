using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GuiConv.Source.ValueHandlers
{
    internal class IntHandler : ValueHandler
    {
        // from int
        public override string Deserialize(string i_string)
        {
            ushort r_ushort = 0;
            uint r_uint = 0;
            ulong r_ulong = 0;

            string o_string = "";

            if (ushort.TryParse(i_string, NumberStyles.Integer, null, out r_ushort))
            {
                o_string = r_ushort.ToString();
            }
            else if (uint.TryParse(i_string, NumberStyles.Integer, null, out r_uint))
            {
                o_string = r_uint.ToString();
            }
            else if (ulong.TryParse(i_string, NumberStyles.Integer, null, out r_ulong))
            {
                o_string = r_ulong.ToString();
            }

            return o_string;
        }

        // to int
        public override string Serialize(string i_string)
        {
            return i_string;
        }
    }
}
