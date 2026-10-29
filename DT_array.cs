using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_3
{
    internal class DT_array
    {
        private int[,] array;

        public DT_array(int n, int m)
        {
            if (n > 0 && m > 0)
            {
                array = new int[n, m];
            }
            else
            {
                Console.WriteLine("Неверный ввод. Создан массив из 1 элемента");
                array = new int[1, 1];
            }

        }

        public DT_array(int n)
        {
            if (n > 0)
            {
                array = new int[n, n];
            }
            else
            {
                Console.WriteLine("Неверный ввод. Создан массив из 1 элемента");
                array = new int[1, 1];
            }
        }

        public void ManualFill()
        {
            int element = 0;
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            Console.WriteLine("Введите элементы массива");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Строка {i + 1}");
                for (int j = 0; j < m; j++)
                {
                    while (!int.TryParse(Console.ReadLine(), out element))
                    {
                        Console.WriteLine("Неверный ввод. Попробуйте снова");
                    }
                    array[i, j] = element;
                }
            }
        }

        public void RandomFill()
        {
            Random rand = new Random();
            int n = array.GetLength(0);
            int element = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    element = rand.Next(100, 1000);
                    if (i != 0)
                    {
                        while (element <= array[i - 1, j])
                        {
                            element = rand.Next(100, i*1000);
                        }
                    }
                    array[i, j] = element;

                }
            }
        }

        public void RandomFillNoRule()
        {
            Random rand = new Random();
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = rand.Next(10, 100);

                }
            }
        }

        private int NextSimple(int num)
        {
            bool not_simple = false;
            while (true)
            {
                num++;
                for (int i = 2; i < (int)Math.Sqrt(num) + 1; i++)
                {
                    if (num % i == 0)
                    {
                        not_simple = true;
                        break;
                    }
                }
                if (not_simple)
                {
                    not_simple = !not_simple;
                }
                else
                {
                    return num;
                }

            }

        }

        public void SimpleFill()
        {
            int element = 2;
            int n = array.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = element;
                    element = NextSimple(element);
                }
            }
        }

        public void MarksFill()
        {
            Random rand = new Random();
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = rand.Next(2, 6);
                }
            }
        }
        public void MarksFillManual()
        {
            Random rand = new Random();
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            int element = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Ученик - {i + 1}");
                for (int j = 0; j < m; j++)
                {
                    while (!(int.TryParse(Console.ReadLine(), out element)) || element > 5 || element < 2)
                    {
                        Console.WriteLine("Неверный ввод. Попробуйте снова");
                    }
                    array[i, j] = element;
                }
            }
        }
        public void MarksOut()
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1} | ");
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.Write("\n");
            }
        }
        public void MarksCount(double number)
        {
            bool was_marks = false;
            double marks_sum = 0;
            double marks_avg = 0;
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            Console.Write($"Номера школьников, со средней оценкой более {number}: ");
            for (int i = 0; i < n; i++)
            {
                marks_sum = 0;
                for (int j = 0; j < m; j++)
                {
                    marks_sum += array[i, j];
                }
                marks_avg = marks_sum / m;
                if (marks_avg >= number)
                {
                    was_marks = true;
                    Console.Write($"{i + 1} ");
                }
            }
            if (!was_marks)
            {
                Console.Write("таких нет.");
            }
            Console.Write("\n");

        }

        public override string ToString()
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            string out_string = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    out_string += $"{array[i, j]} ";
                }
                out_string += "\n";
            }
            return out_string;
        }

        public DT_array T()
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            DT_array array_t = new(m, n);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array_t.array[i, j] = this.array[j, i];
                }
            }
            return array_t;
        }

        public static DT_array operator +(DT_array A, DT_array B)
        {
            if (A.array.GetLength(0) == B.array.GetLength(0) &&
                A.array.GetLength(1) == B.array.GetLength(1))
            {
                int n = A.array.GetLength(0);
                int m = A.array.GetLength(1);
                DT_array C = new(n, m);
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        C.array[i, j] = A.array[i, j] + B.array[i, j];
                    }
                }
                return C;
            }
            else
            {
                Console.WriteLine("Невозможно выполнить сложение.");
                return null;
            }

        }

        public static DT_array operator -(DT_array A, DT_array B)
        {
            if (A.array.GetLength(0) == B.array.GetLength(0) &&
                A.array.GetLength(1) == B.array.GetLength(1))
            {
                int n = A.array.GetLength(0);
                int m = A.array.GetLength(1);
                DT_array C = new(n, m);
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        C.array[i, j] = A.array[i, j] - B.array[i, j];
                    }
                }
                return C;
            }
            else
            {
                Console.WriteLine("Невозможно выполнить вычитание.");
                return null;
            }
        }

        public static DT_array operator *(DT_array A, DT_array B)
        {
            if (A.array.GetLength(1) == B.array.GetLength(0))
            {
                int n = A.array.GetLength(0);
                int m = B.array.GetLength(1);
                int p = A.array.GetLength(1);
                DT_array C = new(n, m);
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < p; j++)
                    {
                        sum = 0;
                        for (int k = 0; k < m; k++)
                        {
                            sum += A.array[i, k] * B.array[k, j];
                        }
                        C.array[i, j] = sum;
                    }
                }
                return C;
            }
            else
            {
                Console.WriteLine("Невозможно выполнить вычитание.");
                return null;
            }
        }

        public static DT_array operator *(int num, DT_array A)
        {
            int n = A.array.GetLength(0);
            int m = A.array.GetLength(1);
            DT_array C = new(n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    C.array[i, j] *= num;
                }
            }
            return C;
        }
    }
}
