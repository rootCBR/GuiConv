using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GuiConv.Source.ValueHandlers
{
    internal class Int32Handler : IntHandler
    {
        // from int32
        public override string Deserialize(string i_string)
        {
            return i_string;
        }

        // to int32
        public override string Serialize(string i_string)
        {
            int r_int = 0;

            if (int.TryParse(i_string, NumberStyles.AllowHexSpecifier, null, out r_int))
            {
                return r_int.ToString();
            }

            return "";
        }
    }
}
