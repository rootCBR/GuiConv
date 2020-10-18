using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GuiConv.Source.ValueHandlers
{
    internal class UInt16Handler : IntHandler
    {
        // from uint16
        public override string Deserialize(string i_string)
        {
            return i_string;
        }

        // to uint16
        public override string Serialize(string i_string)
        {
            ushort r_ushort = 0;

            if (ushort.TryParse(i_string, NumberStyles.AllowHexSpecifier, null, out r_ushort))
            {
                return r_ushort.ToString();
            }

            return "";
        }
    }
}
