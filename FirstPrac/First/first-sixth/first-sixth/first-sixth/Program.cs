//Console.WriteLine("test");

using fifth;

namespace first_fourth_sixth
{
    public class ClassA { };
    public class ClassB : ClassA { };

    class Program
    {
        static void Main(string[] args)
        {

            //                  Задание 1
            //                  
            // 1. Неявное преобразование простых и ссылочных типов, 
            // в виде комментариев внести в программу таблицу неявных 
            // преобразований;
            //

            {
                byte i = 10;
                int b = i; // неявное преобразование byte в int
            }

            {
                int i = 5;
                double b = i + 0.5; // неявное преобразование int в double
            }

            {
                ClassB i = new ClassB(); // неявное преобразование ссылочных типов
                ClassA b = i;
            }

            //	        ТАБЛИЦА НЕЯВНЫХ ПРЕОБРАЗОВАНИЙ 
            //	 sbyte -> short, int, tong, -float, double или decimal
            //	 byte -> short, ushort, int, uint, long, float, double или decimal 
            //	 short -> int, long, -float, double или decimal
            //	 ushort -> int, uint, long, ulong, -float, double или decimal
            //	 int	-> long, -float, double или decimal
            //	 uint -> long, ulong, -float, double или decimal
            //	 long -> float, double или decimal
            //	 char -> ushort, int, uint, long, ulong, -float, double или decimal
            //	 float -> double
            //	 ulong -> float, double или decimal
            //


            // 2. Явное преобразование простых и ссылочных типов, 
            // в виде комментариев внести в программу таблицу 
            // явных преобразований;
            //

            {
                int i = 10;
                byte b = (byte)i; // явное преобразование int в byte
            }

            {
                double d = 3.14;
                int i = (int)d; // явное преобразование double в int
            }

            {
                ClassA b = new ClassB();
                ClassB i = (ClassB)b; // явное преобразование ссылочных типов
            }

            //
            //         ТАБЛИЦА ЯВНЫХ ПРЕОБРАЗОВАНИЙ 	
            // sbyte  -> byte, ushort, uint, ulong или char 
            // byte -> sbyte или char
            // short ->	sbyte, byte, ushort, uint, ulong или char	
            // ushort -> sbyte, byte, short	или char			
            // int -> sbyte, byte, short, ushort, uint, ulonc или char
            // uint -> sbyte, byte,	short, ushort, int или char		
            // long -> sbyte, byte, short, ushort, int, uint, ulong или char
            // ulong ->	sbyte, byte, short, ushort, int, uint, long или char
            // char -> sbyte, byte или short					
            // float ->	sbyte, byte, short, ushort, int, uint, long, ulong, char или decimal
            // double -> sbyte, byte, short, ushort, int, uint, long, ulong, char, float или decimal,
            // decimal -> sbyte, byte, short, ushort, int, uint, long, ulong, char, float или double
            //

            // 3. Вызвать и обработать исключение преобразования типов;
            {
                string s = "2";
                try
                {
                    int i = int.Parse(s); //Преобразует строковое представление числа в эквивалентное ему число двойной точности с плавающей запятой.
                    Console.WriteLine($"Значение: {i}");
                }
                catch (FormatException ex) //Исключение, которое возникает в случае, если формат аргумента недопустим или строка составного формата построена неправильно.
                {
                    Console.WriteLine($"Произошло исключение: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Конец программы.");
                }

            }

            // 4. Безопасное приведение ссылочных типов с помощью операторов as и is;
            {
                // is (возвращает boolean)
                {
                    object obj = "строка";
                    if (obj is string)
                    {
                        Console.WriteLine("строка");
                    }
                    else
                    {
                        Console.WriteLine("не строка");
                    }
                }

                // as (кастит и возвращает обьект или null)
                {
                    object obj = "строка";
                    string? s = obj as string;
                    if (s != null)
                    {
                        Console.WriteLine("строка");
                    }
                    else
                    {
                        Console.WriteLine("не строка");
                    }
                }
            }

            {
                MyClass a = new MyClass() { Value = 3 };
                int i = a; // неявное преобразование
            }

            {
                MyClass2 a = new MyClass2() { Value = 3.14 };
                int i = (int)a; // явное преобразование
            }

            // 6. Преобразование с помощью класса Convert и преобразование строки в число с помощью методов Parse, TryParse класса System.Int32.

            {
                // Примеры преобразования с помощью класса Convert:

                // Преобразование строки в целочисленное значение
                string numberStr = "12345";
                int number = Convert.ToInt32(numberStr);

                // Преобразование числа с плавающей точкой в строку
                double doubleNumber = 10.5;
                string doubleStr = Convert.ToString(doubleNumber);
            }

            {
                // Преобразование строки в целочисленное значение с использованием метода Parse
                string numberStr = "12345";
                int number = int.Parse(numberStr);
            }

            {
                // Преобразование строки в целочисленное значение с использованием метода TryParse
                string numberStr = "123a";
                int number;
                bool success = int.TryParse(numberStr, out number);
                if (success)
                {
                    Console.WriteLine($"Преобразование прошло успешно: {number}"); 
                }
                else
                {
                    Console.WriteLine("Преобразование не удалось");
                }
            }

        }
    }
}

namespace fifth{
    // 5. Пользовательское преобразование типов Implicit(Явное), Explicit(Неявное);
    class MyClass
    {
        public int Value { get; set; }
        public static implicit operator int(MyClass mc)
        {
            Console.WriteLine($"Impl: {mc.Value}");
            return mc.Value; // явное преобразование
        }
    }
    class MyClass2
    {
        public double Value { get; set; }
        public static explicit operator int(MyClass2 mc)
        {
            Console.WriteLine($"Expl: {mc.Value}");
            return (int)mc.Value; // неявное преобразование
        }
    }
}

    