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
            short r_short = 0;
            int r_int = 0;
            long r_long = 0;

            string o_string = "";

            if (short.TryParse(i_string, NumberStyles.Integer, null, out r_short))
            {
                o_string = r_short.ToString();
            }
            else if (int.TryParse(i_string, NumberStyles.Integer, null, out r_int))
            {
                o_string = r_int.ToString();
            }
            else if (long.TryParse(i_string, NumberStyles.Integer, null, out r_long))
            {
                o_string = r_long.ToString();
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
