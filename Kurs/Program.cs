using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Kurs
{
    class Program
    {
        // ввод первого массива
        public static int[,] Input()
        {
            int[,] a = new int[4, 4];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("a[{0},{1}]=", i, j);
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            return a;
        }

        //создание второго массива
        public static int[,] MakeSecond(int [,]a)
        {
            int[,] b = new int[4, 4];
            for (int i = 0; i < b.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    b[i, j] = 0;
            //заполнение второго массива значениями
            for (int i = 0; i < b.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k <= j; k++)
                        b[i, j] += a[i, k];
            return b;
        }

        //высчитывание значения суммы положительных элементов четных строк и четных столбцов
        public static int Sum(int [,]b)
        {
            int sum = 0;
            for (int i = 0; i < b.GetLength(0); i ++)
                for (int j = 0; j < b.GetLength(1); j++)
                    //если четные и положительные
                    if(i%2==1 && j%2==1 && b[i,j]>0)
                        sum += b[i, j];
            return sum;
            
        }

        //поиск максимального элемента четных строк
        public static int Max(int [,]b)
        {
            int max = b[1,1];
            //пробегаем четные строки
            for (int i = 0; i < b.GetLength(0); i++)
                if(i%2==1)
                //каждый столбец четной строки
                for (int j = 0; j < b.GetLength(1); j ++)
                    if (max < b[i, j])
                        max = b[i, j];
            return max;
        }
        //вывод массива на экран
        public static void OutPut(int [,]a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write(a[i, j] + "\t");
                Console.WriteLine();
            }
        }

        //сохранение массива в файл
        public static void OutPut(int[,] a,StreamWriter wr)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    wr.Write(a[i, j] + "\t");
                wr.WriteLine();
            }
        }

        public static double CalcMath(int sum)
        {
            try
            {
                return 1 / (Math.Sqrt(sum) + Math.Sqrt(2));
            }
            catch (Exception e) {
                Console.WriteLine("Ошибка при расчете математического выражения");
                return -1;
            }
        }
        //точка входа в програму
        static void Main(string[] args)
        {
            Console.WriteLine("Введите элементы первого массива");
            //заполняем первый массив
            int[,] a = Input();
            //делаем второй массив
            int[,] b = MakeSecond(a);
            int sum = Sum(b);
            int max = Max(b);
            double z = CalcMath(sum);
            Console.WriteLine("Элементы первого массива");
            OutPut(a);
            Console.WriteLine("Элементы второго массива");
            OutPut(b);
            Console.WriteLine("Сумма положительных элементов четных строк и четных столбцов равна "+sum);
            Console.WriteLine("Максимальный элемент четных строкравен "+max);
            Console.WriteLine("Результат математического выражения {0:f2}",z);
            StreamWriter wr = new StreamWriter("Answer.txt");

            wr.WriteLine("Элементы первого массива");
            OutPut(a, wr);
            wr.WriteLine("Элементы второго массива");
            OutPut(b, wr);
            wr.WriteLine("Сумма положительных элементов четных строк и четных столбцов равна " + sum);
            wr.WriteLine("Максимальный элемент четных строкравен " + max);
            wr.WriteLine("Результат математического выражения {0:f2}", z);
            wr.Close();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
