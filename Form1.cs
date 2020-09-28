using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiConv
{
    public partial class Form1 : Form
    {
        private bool AllowSwitchEndian = false;
        private Converter.ValueType CurrentInputType;
        private Converter.ValueType CurrentOutputType;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            textBox1.KeyDown += new KeyEventHandler(TextBox1_KeyDown);

            Converter.ValueTypeInfo[] inputValueTypesInfos = Converter.GetCompatibleValueTypes(Converter.ValueTypeCompatibility.Input);
            Converter.ValueTypeInfo[] outputValueTypesInfos = Converter.GetCompatibleValueTypes(Converter.ValueTypeCompatibility.Output);

            foreach (Converter.ValueTypeInfo valueTypeInfo in inputValueTypesInfos)
            {
                comboBox1.Items.Add(valueTypeInfo.name);
            }

            foreach (Converter.ValueTypeInfo valueTypeInfo in outputValueTypesInfos)
            {
                comboBox2.Items.Add(valueTypeInfo.name);
            }

            //Console.WriteLine($"Number of input value types: {comboBox1.Items.Count}");
            //Console.WriteLine($"Number of output value types: {comboBox2.Items.Count}");

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            InitConvert();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                e.SuppressKeyPress = true;

                InitConvert();

                e.Handled = true;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            InitConvert();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                CurrentInputType = Converter.GetValueTypeFromSelected((string)comboBox1.SelectedItem);

                SetAllowSwitchEndian();
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > -1)
            {
                CurrentOutputType = Converter.GetValueTypeFromSelected((string)comboBox2.SelectedItem);

                SetAllowSwitchEndian();
            }
        }

        private void InitConvert()
        {
            textBox2.Text = Converter.Convert(CurrentInputType, CurrentOutputType, textBox1.Text);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Converter.UseBigEndian = checkBox1.Checked;

            InitConvert();
        }

        private void SetAllowSwitchEndian()
        {
            Console.WriteLine("Set allow switch endian");

            bool condition = Converter.GetValueTypeAllowSwitchEndian(CurrentInputType, CurrentOutputType);

            if (condition != AllowSwitchEndian)
            {
                AllowSwitchEndian = condition;
            }

            SetEndianCheckbox(AllowSwitchEndian);

            InitConvert();
        }

        private void SetEndianCheckbox(bool enable)
        {
            checkBox1.Enabled = enable;
        }
    }
}
