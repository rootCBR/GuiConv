using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GuiConv.Source.ValueHandlers
{
    internal class FloatHandler : ValueHandler
    {
        // from float
        public override string Deserialize(string i_string)
        {
            float r_float = 0;
            string o_string = "";

            if (float.TryParse(i_string, NumberStyles.Any, null, out r_float))
            {
                byte[] bytes = BitConverter.GetBytes(r_float);

                if (bytes.Length == 4)
                {
                    o_string = i_string;
                }
            }

            return o_string;
        }

        // to float
        public override string Serialize(string i_string)
        {
            /*
            float r_float = float.Parse(i_string, CultureInfo.InvariantCulture.NumberFormat);
            string o_string = r_float.ToString().Replace(",", ".");

            return o_string;
            */

            string o_string = "";
            float r_float = 0;

            if (float.TryParse(i_string, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out r_float))
            {
                o_string = r_float.ToString().Replace(",", ".");
            }

            return o_string;
        }
    }
}
