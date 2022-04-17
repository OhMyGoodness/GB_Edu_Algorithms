/* Geekbrains 17.04.2022
 Лазин Данил
 */
using System;
using System.Linq;

namespace GeekBrains_EDU
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Урок 1. Простые алгоритмы");
            Console.Write("Введите номер задачи: ");
            // не делаем проверку на чистое число, а берём за факт что уже введено число
            var itemNumber = Console.ReadLine();
            Console.WriteLine();
            
            RunMethod(itemNumber);
        }

        static void RunMethod(string number)
        {
            var methodName = "Task_" + number;
            var method = AppDomain.CurrentDomain.GetAssemblies()
                .Select(x => x.GetTypes())
                .SelectMany(x => x)
                .Where(x => x.Namespace == "GeekBrains_EDU")
                .Where(c => c.GetMethod(methodName) != null)
                .Select(c => c.GetMethod(methodName)).FirstOrDefault();
            if (method != null)
            {
                method.Invoke(null, null);
            }
            else
            {
                Console.WriteLine("Указанный метод не найден.");
            }
        }
        
        public static void Task_1()
        {
            Console.Write("Введите вес человека: ");
            var weight = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Введите рост человека в метрах: ");
            var height = Convert.ToDouble(Console.ReadLine());

            double index = weight / (height * height);
            
            Console.WriteLine("Индекс массы тела равен: " + index);
        }

        public static void Task_2()
        {
            Console.Write("Введите 4 числа через пробел: ");
            var numbersStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(numbersStr))
            {
                return;
            }
            
            var numbers = numbersStr.Split(' ').Select(Convert.ToDouble).ToArray();

            double maxNumber = numbers[0];
            //maxNumber = numbers.Max(i => i); :)
                
            for (var i = 1; i < numbers.Count(); i++)
            {
                if (maxNumber <= numbers[i])
                {
                    maxNumber = numbers[i];
                }
                    
            }
            
            Console.WriteLine("Максимальное число: " + maxNumber);
        }

        public static void Task_3()
        {
            var a = 123;
            var b = 456;

            Console.WriteLine($"Исходное значение a = {a}, b = {b}");
            
            a = a + b;
            b = b - a;
            b = -b;
            a = a - b;
            
            Console.WriteLine($"Замена без третьей переменной a = {a}, b = {b}");
        }

        public static void Task_4()
        {
            double a, b, c, x, x1, x2, d;
            
            Console.Write("a = ");
            a = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("b = ");
            b = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("c = ");
            c = Convert.ToDouble(Console.ReadLine());
 
            d = b * b - 4 * a * c;
            if (a == 0)
            {
                if(b == 0)
                {
                    Console.WriteLine(c == 0 ? "x = 0 ?" : "Нет корня");
                }
                else
                {
                    x = -c / b;
                    Console.WriteLine($"x = {x}");
                }
            }
            else if (d > 0)
            {
                x1 = (-b + Math.Sqrt(d)) / 2 * a;
                x2 = (-b - Math.Sqrt(d)) / 2 * a;
                Console.WriteLine($"x1 = {x1} \nx2 ={x2} ");
            }
            else if (d == 0)
            {
                x = -b/2*a;
                Console.WriteLine($"x = {x}");
            }
            else
            {
                Console.WriteLine("Нет корня");
            }
        }

        public static void Task_5()
        {
            string[] types = new string[] { "Зима", "Весна", "Лето", "Осень" };
            
            Console.Write("Введите номер месяца: ");
            var month = Convert.ToInt32(Console.ReadLine());
            if (month == 12) month = 0;

            int type = Convert.ToInt32(Math.Floor((double)month / 3));
            Console.WriteLine($"Время года: {types[type]}");
        }

        public static void Task_6()
        {
            Console.Write("Введите возраст: ");
            var result = "";
            var years = Convert.ToInt32(Console.ReadLine());

            if (years < 10)
            {
                
            }
            else
            {
                var last2Nums = years.ToString().Substring(years.ToString().Length-2);
                if (last2Nums[0] == '1' || (last2Nums[1] == '0' || Convert.ToInt32(last2Nums[1].ToString()) >= 5))
                {
                    var aaa = Convert.ToInt32(last2Nums[1]);
                    result = "лет";
                }
                else if (last2Nums[1] == '1')
                {
                    result = "год";
                } else if (Convert.ToInt32(last2Nums[1].ToString()) >= 2 && Convert.ToInt32(last2Nums[1].ToString()) <= 4)
                {
                    result = "года";
                }
            }
            
            Console.WriteLine($"Возраст: {years} {result}");
        }

        public static void Task_7()
        {
            // y1, x1 - будет означать белое поле - НЕЧЕТНОЕ
            Console.Write("x1 = ");
            int x1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("y1 = ");
            int y1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("x2 = ");
            int x2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("y2 = ");
            int y2 = Convert.ToInt32(Console.ReadLine());

            int firstCoordIsBlack = ((y1 - 1) + x1) % 2;
            int secondCoordIsBlack = ((y2 - 1) + x2) % 2;

            Console.WriteLine(firstCoordIsBlack == secondCoordIsBlack ? "Цвета относятся к одному цвету" : "Цвета не относятся к одному цвету");
        }

        public static void Task_8()
        {
            Console.Write("(integer) a = ");
            var a = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("(integer) b = ");
            var b = Convert.ToInt32(Console.ReadLine());

            for (var i = a; i <= b; i++)
            {
                Console.WriteLine($"Число {i}, квадрат {Math.Pow(i, 2)}, куб = {Math.Pow(i, 3)}");
            }
        }

        public static void Task_9()
        {
            Console.Write("N = ");
            var n = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("K = ");
            var k = Convert.ToInt32(Console.ReadLine());

            var chastnoe = 0;
            var ostatok = n;
            
            while (ostatok >= k)
            {
                ostatok -= k;
                chastnoe++;
            }
            
            Console.WriteLine($"Частное = {chastnoe}, остаток: {ostatok}");
        }

        public static void Task_10()
        {
            Console.Write("N = ");
            var n = Convert.ToInt32(Console.ReadLine());

            if (n < 0) return;

            var result = false;
            for (var i = 0; i < n.ToString().Length; i++)
            {
                var num = Convert.ToInt32(n.ToString()[i]);
                if (num % 2 != 0)
                {
                    result = true;
                    break;
                }
            }
            
            Console.WriteLine("В записи числа имеются нечетные числа: " + result);
        }

        public static void Task_11()
        {
            // тут не будем использовать LINQ, будем считать руками :)
            var totalSum = 0;
            var counter = 0;
            
            while (true)
            {
                Console.Write("\rВводите целые числа, число 0 прерывает ввод: ");
                var n = Convert.ToInt32(Console.ReadLine());

                if (n == 0) break;

                if (n.ToString()[n.ToString().Length - 1] == '8')
                {
                    totalSum += n;
                    counter++;
                }
            }
            
            Console.WriteLine("Среднее значение: " + (totalSum / counter));
        }

        public static void Task_12()
        {
            // :)
            Console.Write("Введите 3 числа через пробел: ");
            var n = (Console.ReadLine())?.Split(' ').Select(i => Convert.ToInt32(i));
            
            Console.WriteLine("Максимальное число: " + n.Max());
        }

        public static void Task_13()
        {
            long getRand(int min, int max)
            {
                long x, a, b, m;
                m = 500; // Вершина последовательности
                b = 3 + DateTime.Now.Ticks;
                a = 2 + DateTime.Now.Ticks;
                x = 1 + DateTime.Now.Ticks;
                int i;
                int modulus = 500;
                for (i = 0; i < modulus; i++)
                {
                    x = (a * x + b) % m;
                    if (x >= min && x <= max)
                    {
                        return x;
                    }
                }
                return 0;
            }

            var num1 = getRand(10, 90);
            var num2 = getRand(10, 90);
            var num3 = getRand(10, 90);
            var num4 = getRand(10, 90);
            
            Console.WriteLine("Случайное число: " + num1);
            Console.WriteLine("Случайное число: " + num2);
            Console.WriteLine("Случайное число: " + num3);
            Console.WriteLine("Случайное число: " + num4);
        }

        public static void Task_14()
        {
            Console.Write("Введите число: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Атоморфные числа: ");
            for (var i = 0; i <= num; i++)
            {
                var sourceLen = i.ToString().Length;
                int result = i * i;

                var endNum = result.ToString().Substring(result.ToString().Length - sourceLen);

                if (endNum == i.ToString())
                {
                    Console.WriteLine(i + " * " + i + " = " + result + " ");
                }
            }
        }
    }
}