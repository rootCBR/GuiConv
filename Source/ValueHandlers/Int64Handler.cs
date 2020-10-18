using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GuiConv.Source.ValueHandlers
{
    internal class Int64Handler : IntHandler
    {
        // from int64
        public override string Deserialize(string i_string)
        {
            return i_string;
        }

        // to int64
        public override string Serialize(string i_string)
        {
            long r_long = 0;

            if (long.TryParse(i_string, NumberStyles.AllowHexSpecifier, null, out r_long))
            {
                return r_long.ToString();
            }

            return "";
        }
    }
}
