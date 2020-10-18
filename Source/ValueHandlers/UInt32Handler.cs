using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GuiConv.Source.ValueHandlers
{
    internal class UInt32Handler : IntHandler
    {
        // from uint32
        public override string Deserialize(string i_string)
        {
            return i_string;
        }

        // to uint32
        public override string Serialize(string i_string)
        {
            uint r_uint = 0;

            if (uint.TryParse(i_string, NumberStyles.AllowHexSpecifier, null, out r_uint))
            {
                return r_uint.ToString();
            }

            return "";
        }
    }
}
