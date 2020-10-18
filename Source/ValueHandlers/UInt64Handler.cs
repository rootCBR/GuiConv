using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GuiConv.Source.ValueHandlers
{
    internal class UInt64Handler : IntHandler
    {
        // from uint64
        public override string Deserialize(string i_string)
        {
            return i_string;
        }

        // to uint64
        public override string Serialize(string i_string)
        {
            ulong r_ulong = 0;

            if (ulong.TryParse(i_string, NumberStyles.AllowHexSpecifier, null, out r_ulong))
            {
                return r_ulong.ToString();
            }

            return "";
        }
    }
}
