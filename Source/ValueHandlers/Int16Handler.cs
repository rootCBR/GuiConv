using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GuiConv.Source.ValueHandlers
{
    internal class Int16Handler : IntHandler
    {
        // from int16
        public override string Deserialize(string i_string)
        {
            return i_string;
        }

        // to int16
        public override string Serialize(string i_string)
        {
            short r_short = 0;

            if (short.TryParse(i_string, NumberStyles.AllowHexSpecifier, null, out r_short))
            {
                return r_short.ToString();
            }

            return "";
        }
    }
}
