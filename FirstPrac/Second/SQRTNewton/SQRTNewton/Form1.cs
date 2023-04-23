using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQRTNewton
{
    public partial class Form1 : Form
    {
        int CurrentIteration = 0;
        decimal CurrentGuess = 0;
        decimal CurrentNextGuess = 0;
        decimal CurrentNumberDecimal = 0;

        decimal Delta = (decimal)Math.Pow(10, -28); // задаем точность вычислений

        public Form1()
        {
            InitializeComponent();
            ClearVariables();
            ClearLabels();
        }

        /// <summary>
        /// call-back функция на click event button1 ("вычислить" (Math.Sqrt))
        /// </summary>
        // вычисление Math.Sqrt (кнопка)
        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out var NumberDouble) && NumberDouble > 0)
            {
                label2.Text = Math.Sqrt(NumberDouble).ToString();
            }
            else
            {
                label2.Text = NumberDouble < 0 ? "Введите положительное число" : "Введите правильный формат числа"; 
            }
        }

        /// <summary>
        /// call-back функция на click event button2 ("выполнить итерацию")
        /// </summary>
        // выполнить итерацию (кнопка)
        private void button2_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out var NumberDecimal) && NumberDecimal >= 0)
            {
                if (NumberDecimal == 0)
                {
                    CurrentNumberDecimal = 0;
                    // обнуление лейблов
                    return;
                }

                if (CurrentNumberDecimal != NumberDecimal) 
                { 
                    CurrentNumberDecimal = NumberDecimal;

                    CurrentGuess =  (decimal)((double)NumberDecimal / 2); // задание начального приближения
                    CurrentNextGuess = (CurrentGuess + NumberDecimal / CurrentGuess) / 2; // вычисление первого приближения
                    CurrentIteration = 0;
                }
            }

            else
            {
                label3.Text = NumberDecimal < 0 ? "Введите положительное число" : "Введите decimal";
                return;
            }

            if (Math.Abs(CurrentNextGuess - CurrentGuess) <= Delta) // проверка условия остановки вычислений
            {
                label3.Text = CurrentNextGuess.ToString();
                return;
            }

            CurrentIteration++;
            CurrentGuess = CurrentNextGuess; // обновление предыдущего значения
            CurrentNextGuess = (CurrentGuess + CurrentNumberDecimal / CurrentGuess) / 2; // вычисление следующего значения

            // вывод текущего приближения
            label3.Text = CurrentNextGuess.ToString();

            //вывод итерации
            label8.Text = CurrentIteration.ToString();

            // вывод погрешности
            label10.Text = (Math.Abs(CurrentNextGuess - CurrentGuess)).ToString();

        }

        /// <summary>
        /// call-back функция на click event button3 ("вычислить" (Метод Ньютона))
        /// </summary>
        //вычислить по Ньютону (кнопка)
        private void button3_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text, out var NumberDecimal) && NumberDecimal >= 0)
            {
                if (NumberDecimal == 0)
                {
                    label3.Text = "0";
                    return;
                }
                
                // используется для начального приближения к корню квадратному в методе Ньютона
                // для приближенного вычисления корня квадратного из заданного числа.

                decimal guess = (decimal)((double)NumberDecimal / 2);
                decimal result = ((NumberDecimal / guess) + guess) / 2;

                while(Math.Abs(result - guess) > Delta)
                {
                    guess = result;
                    result = ((NumberDecimal / guess) + guess) / 2;
                }

                // вывод результата
                label3.Text = result.ToString();
            }
            else
            {
                label3.Text = NumberDecimal < 0 ? "Введите положительное число" : "Введите decimal";
            }
        }


        /// <summary>
        /// функция зануляет переменные CurrentIteration, CurrentGuess, CurrentNextGuess, CurrentNumberDecimal
        /// </summary>
        // очитстка переменных
        void ClearVariables()
        {
            CurrentIteration = 0;
            CurrentGuess = 0;
            CurrentNextGuess = 0;
            CurrentNumberDecimal = 0;
        }

        /// <summary>
        /// очищает label3, label8, label10, label2 от текста
        /// </summary>
        // очитстка лейблов
        void ClearLabels() 
        {
            label3.Text = "";
            label8.Text = "";
            label10.Text = "";
            label2.Text = "";
        }

        /// <summary>
        /// call-back функция на TextChanged event у textBox1
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ClearVariables();
            ClearLabels();
        }
    }
}
