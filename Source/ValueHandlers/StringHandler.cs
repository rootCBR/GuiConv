using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiConv.Source.ValueHandlers
{
    internal class StringHandler : ValueHandler
    {
        public override string Deserialize(string value)
        {
            return value;
        }

        public override string Serialize(string value)
        {
            return value;
        }
    }
}
