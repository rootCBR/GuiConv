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
        public override string Deserialize(string i_string)
        {
            short r_short = 0;
            int r_int = 0;
            long r_long = 0;

            string o_string = "";

            if (int.TryParse(i_string, NumberStyles.AllowHexSpecifier, null, out r_int) ||
                long.TryParse(i_string, NumberStyles.AllowHexSpecifier, null, out r_long) ||
                short.TryParse(i_string, NumberStyles.AllowHexSpecifier, null, out r_short))
            {
                o_string = i_string;
            }

            return o_string;
        }

        public override string Serialize(string i_string)
        {
            return i_string;
        }
    }
}
