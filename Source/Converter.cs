using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiConv
{
    public class Converter
    {
        public static bool UseBigEndian = false;

        public static readonly Dictionary<ValueType, ValueTypeInfo> ValueTypes = new Dictionary<ValueType, ValueTypeInfo>
        {
            [ValueType.String] = new ValueTypeInfo
            {
                handler = new Source.ValueHandlers.StringHandler(),
                name = "String",
                compatibility = ValueTypeCompatibility.Both,
                typesAllowSwitchEndian = new ValueType[] {
                        ValueType.CRC32,
                        ValueType.CRC64,
                        ValueType.CRC64_WD2,
                        ValueType.FNV64,
                        ValueType.FNV64_WD1
                },
            },
            [ValueType.Hex] = new ValueTypeInfo
            {
                handler = new Source.ValueHandlers.HexHandler(),
                name = "Hex",
                compatibility = ValueTypeCompatibility.Both,
                typesAllowSwitchEndian = new ValueType[] {
                        ValueType.Float
                },
            },
            [ValueType.Float] = new ValueTypeInfo
            {
                handler = new Source.ValueHandlers.FloatHandler(),
                name = "Float",
                compatibility = ValueTypeCompatibility.Output,
                typesAllowSwitchEndian = new ValueType[] { },
            },
            [ValueType.CRC32] = new ValueTypeInfo
            {
                handler = new Source.ValueHandlers.CRC32Handler(),
                name = "CRC32",
                compatibility = ValueTypeCompatibility.Output,
                typesAllowSwitchEndian = new ValueType[] { },
            },
            [ValueType.CRC64] = new ValueTypeInfo
            {
                handler = new Source.ValueHandlers.CRC64Handler(),
                name = "CRC64",
                compatibility = ValueTypeCompatibility.Output,
                typesAllowSwitchEndian = new ValueType[] { },
            },
            [ValueType.CRC64_WD2] = new ValueTypeInfo
            {
                handler = new Source.ValueHandlers.CRC64Handler_WD2(),
                name = "CRC64 (WD2)",
                compatibility = ValueTypeCompatibility.Output,
                typesAllowSwitchEndian = new ValueType[] { },
            },
            [ValueType.FNV64] = new ValueTypeInfo
            {
                handler = new Source.ValueHandlers.FNV64Handler(),
                name = "FNV64",
                compatibility = ValueTypeCompatibility.Output,
                typesAllowSwitchEndian = new ValueType[] { },
            },
            [ValueType.FNV64_WD1] = new ValueTypeInfo
            {
                handler = new Source.ValueHandlers.FNV64Handler_WD1(),
                name = "FNV64 (WD1)",
                compatibility = ValueTypeCompatibility.Output,
                typesAllowSwitchEndian = new ValueType[] { },
            },
        };

        public struct ValueTypeInfo
        {
            public IValueHandler handler;
            public string name;
            public ValueTypeCompatibility compatibility;
            public ValueType[] typesAllowSwitchEndian;
        }

        public enum ValueTypeCompatibility
        {
            None,
            Input,
            Output,
            Both
        }

        public enum ValueType
        {
            String,
            Decimal,
            Hex,
            Float,
            Int8,
            Int16,
            Int32,
            Int64,
            UInt8,
            UInt16,
            UInt32,
            UInt64,
            CRC32,
            CRC32_R,
            CRC64,
            CRC64_R,
            CRC64_WD2,
            FNV64,
            FNV64_WD1
        }

        static Converter()
        {

        }

        public static string EnterConversion()
        {
            return "";
        }

        public static string ExitConversion()
        {
            return "";
        }
        
        public static string Convert(ValueType inputValueType, ValueType outputValueType, string value)
        {
            var deserializeHandler = ValueTypes[inputValueType].handler as IValueHandler;
            var serializeHandler = ValueTypes[outputValueType].handler as IValueHandler;

            var deserializedValue = deserializeHandler.PreProcess(value);
            var serializedValue = serializeHandler.PostProcess(deserializedValue);

            return serializedValue;
        }

        public static ValueTypeInfo[] GetCompatibleValueTypes(ValueTypeCompatibility compatibility)
        {
            List<ValueTypeInfo> output = new List<ValueTypeInfo>();

            foreach (KeyValuePair<ValueType, ValueTypeInfo> valueTypeInfo in ValueTypes)
            {
                bool add = false;
                ValueTypeCompatibility currentCompatibility = valueTypeInfo.Value.compatibility;

                if (currentCompatibility == compatibility)
                {
                    add = true;
                }
                else
                {
                    if (compatibility == ValueTypeCompatibility.Input &&
                        currentCompatibility == ValueTypeCompatibility.Both)
                    {
                        add = true;
                    }
                    else 
                    if (compatibility == ValueTypeCompatibility.Output &&
                        currentCompatibility == ValueTypeCompatibility.Both)
                    {
                        add = true;
                    }
                }

                //Console.WriteLine($"Compatibility\n\ttarget: {compatibility}\n\tcurrent: {currentCompatibility}\n\t-> {add}");

                if (add == true)
                {
                    output.Add(valueTypeInfo.Value);
                }
            }

            return output.ToArray();
        }

        public static ValueType GetValueTypeFromSelected(string selectedValueTypeName)
        {
            foreach (KeyValuePair<ValueType, ValueTypeInfo> valueTypeInfo in ValueTypes)
            {
                string currentName = valueTypeInfo.Value.name;

                if (currentName == selectedValueTypeName)
                {
                    return valueTypeInfo.Key;
                }
            }

            return ValueType.String;
        }

        public static bool GetValueTypeAllowSwitchEndian(ValueType inputValueType, ValueType outputValueType)
        {
            foreach (KeyValuePair<ValueType, ValueTypeInfo> valueTypeInfo in ValueTypes)
            {
                foreach (ValueType type in valueTypeInfo.Value.typesAllowSwitchEndian)
                {
                    Console.WriteLine($"Get allow switch endian\n\tinput: {inputValueType}\n\toutput: {outputValueType}\n\tcurrent: {type}");

                    if (valueTypeInfo.Key == inputValueType &&
                        type == outputValueType)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    public interface IValueHandler
    {
        string PreProcess(string value);
        string PostProcess(string value);
    }

    internal abstract class ValueHandler : IValueHandler
    {
        // IN: string to target value type
        public abstract string Deserialize(string text);

        // OUT: converted value type to string
        public abstract string Serialize(string value);

        public string PreProcess(string value)
        {
            return this.Deserialize(value);
        }

        public string PostProcess(string value)
        {
            return this.Serialize(value);
        }
    }
}
