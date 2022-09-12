using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private int _x;
        private int x
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
                textBox1.Text = _x.ToString();
            }
        }
        private Operation operation = Operation.None;
        private bool newNumber = true;
        public Form1()
        {
            InitializeComponent();
            x = 0;
        }
        private void buttonDigit_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string tag = (string)b.Tag;
            int digit = int.Parse(tag);
            if (newNumber)
            {
                x = digit;
                newNumber = false;
            }
            else
            {
                x = 10 * x + digit;
            }
        }
        private int y;

        //private string operation;
        //private void buttonOperation_Click(object sender, EventArgs e)
        //{
        //    y = x;
        //    Button b = (Button)sender;
        //    operation = (string)b.Tag;
        //    newNumber = true;
        //}

        //private void buttonResult_Click(object sender, EventArgs e)
        //{
        //    switch (operation)
        //    {
        //        case "10":
        //            x = y + x;
        //            break;
        //        case "11":
        //            x = y - x;
        //            break;
        //        case "12":
        //            x = y * x;
        //            break;
        //        case "13":
        //            x = y / x;
        //            break;
        //    }
        //    newNumber = true;
        //}
        private void buttonOperation_Click(object sender, EventArgs e)
        {
            y = x;
            Button b = (Button)sender;
            string tag = (string)b.Tag;
            Enum.TryParse(tag, out operation);
            newNumber = true;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case Operation.Addition:
                    x = y + x;
                    break;
                case Operation.Subtraction:
                    x = y - x;
                    break;
                case Operation.Multiplication:
                    x = y * x;
                    break;
                case Operation.Division:
                    x = y / x;
                    break;
                case Operation.Sqrt:
                    x = (int)Math.Sqrt(Convert.ToDouble(x));
                    break;
                case Operation.Pow:
                    x = (int)Math.Pow(x, 2);
                    break;
            }
            newNumber = true;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                int value;
                if (int.TryParse(Clipboard.GetText(), out value))
                {
                    x = value;
                }
            }
        }

        private void buttonClearTextBox_Click(object sender, EventArgs e)
        {
            x = 0;
        }
    }
}
