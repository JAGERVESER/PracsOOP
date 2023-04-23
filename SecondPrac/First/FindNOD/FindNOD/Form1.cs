using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FindNOD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = "";
            label3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // разделитель строки 
            string[] Params = textBox1.Text.Split(',');
            // проверка на валидность введенных данных
            foreach (var i in Params)
            {
                if (!int.TryParse(i, out var par))
                {
                    label2.Text = "Введите правильный формат чисел : число_1,число_2,...,число_N";
                    return;
                }
            }

            // проверка на валидность введенных данных
            if (Params.Length != 0 && Params.Length != 1)
            {
                // создаем массив в который запишем числа из массива строк Params
                int[] IntParams = new int[Params.Length];

                for (int i = 0; i < Params.Length; i++)
                {
                    IntParams[i] = Convert.ToInt32(Params[i]);
                }

                var timer = new Stopwatch(); // создаем объект Stopwatch

                timer.Start(); // запускаем таймер
                var NODEuclid = FindNOD(IntParams);
                var TimeEuclid = timer.Elapsed;

                timer.Restart(); // перезапускаем таймер
                var NODStein = FindNOD(IntParams);
                var TimeStein = timer.Elapsed;
                
                // конкатенируем строки и выводим в лейблах 
                label2.Text = "Метод Евклида : " + NODEuclid.ToString() + "; Время : " + TimeEuclid.TotalMilliseconds.ToString();
                label3.Text = "Метод Штейна : " + NODStein.ToString() + "; Время : " + TimeStein.TotalMilliseconds.ToString();

            }
            else
            {
                label2.Text = "Должно быть как минимум два числа";
            }
        }

        // алгоритм евклида
        static public int FindNOD(int A, int B)
        {
            if (A == 0) return B;
            while (B != 0)
            {
                if (A > B) A -= B;
                else B -= A;
            }
            return A;
        }
        // перегрузки алгоритма евклида
        static public int FindNOD(int A, int B, int C)
        {
            return FindNOD(FindNOD(A, B), C);
        }
        static public int FindNOD(int A, int B, int C, int D)
        {
            return FindNOD(FindNOD(A, B, C), D);
        }
        static public int FindNOD(int A, int B, int C, int D, int E)
        {
            return FindNOD(FindNOD(A, B, C, E), D);
        }
        public static int FindNOD(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return -1;

            int result = numbers[0]; 
            for (int i = 1; i < numbers.Length; i++)
            {
                result = FindNOD(result, numbers[i]);
               
            }
            
            return result;
        }

        // алгоритм штейна
        static public int FindGCDStein(int u, int v)
        {
            int k; // переменная для отслеживания количества делений на 2

            if (u == 0 || v == 0) return u | v; // если один из аргументов равен 0, возвращает другой аргумент или 0, если оба аргумента равны 0.

            for (k = 0; ((u | v) & 1) == 0; ++k) // проверяет четность обоих чисел, пока они не станут нечетными, и считает количество делений на 2
            {
                u >>= 1;
                v >>= 1;
            }

            while ((u & 1) == 0) // пока u четное, делим его на 2
                u >>= 1;

            do // выполняем алгоритм Стейна
            {
                while ((v & 1) == 0) // пока v четное, делим его на 2
                    v >>= 1;
                if (u < v) // если u меньше v, меняем их местами
                {
                    v -= u;
                }
                else
                {
                    int diff = u - v; // находим разность между u и v
                    u = v; // присваиваем v значение u для следующей итерации
                    v = diff; // присваиваем diff значение v для следующей итерации
                }
                v >>= 1; // делим v на 2
            } while (v != 0);

            u <<= k; // умножаем оставшееся нечетное число (u) на количество делений на 2 в начале, чтобы получить НОД входных аргументов
            return u; // возвращаем НОД
        }
        // перегрузка алгоритма штейна для массива целых чисел
        public static int FindGCDStein(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return -1;

            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = FindGCDStein(result, numbers[i]);

            }

            return result;
        }
    }
    
}
