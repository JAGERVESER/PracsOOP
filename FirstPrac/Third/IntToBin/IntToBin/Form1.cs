using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntToBin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder binary = new StringBuilder();
            if(int.TryParse(textBox1.Text, out var num))
            {
                if (num < 0)
                {
                    label1.Text = "Введите положительный int";
                }

                else
                {
                    
                    do
                    {
                        int reminder = num % 2;
                        num /= 2;
                        binary.Insert(0, reminder);
                    } while (num > 0);

                    label1.Text = binary.ToString();
                }
            }
            else
            {
                label1.Text = "Введите число формата int";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
