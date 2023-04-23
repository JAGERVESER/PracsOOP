using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seventh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += AllowOnlyDoubleInput;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AllowOnlyDoubleInput(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            // Разрешенные символы: числа 0-9, знак минуса и точка.
            if (!Char.IsDigit(ch) // проверка на десятичное число
                && ch != '-'
                && ch != '.'
                && !((ch == '.') && (textBox1.Text.IndexOf('.') == -1))
                && !((ch == '-') && (textBox1.SelectionStart == 0
                && textBox1.Text.IndexOf('-') == -1))
                && !(ch == '.' && double.TryParse(textBox1.Text + ch.ToString(), out var num)))
            {
                e.Handled = true; // флаг позволяющий или не позволяющий вводить (true - не позволять false - позволять)
            }
            else if (!(ch == '.' && textBox1.Text.Contains(".")) // проверка на повторение (если будет повторение то не вводим)
                && !(ch == '-' && textBox1.Text.Contains("-"))
                && !(ch == '-' && textBox1.Text.Length >= 1)) // проверка на первый символ (если первый то вводить можно)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1 && (textBox1.Text[textBox1.Text.Length - 1]) == '.')
            {
                textBox1.Text += '0';
            }
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".0";
            }
        }

    }
}
