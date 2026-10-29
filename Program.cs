using lab_3;
using System;

internal class Program
{
    public static void Main(string[] args)
    {
        int option = 1;
        while (option != 0)
        {
            Console.WriteLine("\nЛабораторная работа 3");
            Console.WriteLine("Введите номер задания 1 - 8 (0 для выхода)");
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Неверный ввод.");
            }
            switch (option)
            {
                case 1:
                    {
                        int n = 0;
                        int m = 0;
                        Console.WriteLine("Введите размеры массива (m и n), который требуется вводить вручную");
                        while (!int.TryParse(Console.ReadLine(), out m) || (m < 1))
                        {
                            Console.WriteLine("Неверный ввод. Введите натуральное число");
                        }
                        while (!int.TryParse(Console.ReadLine(), out n) || (n < 1))
                        {
                            Console.WriteLine("Неверный ввод. Введите натуральное число");
                        }
                        DT_array array_1 = new(m, n);
                        array_1.ManualFill();
                        Console.WriteLine(array_1.ToString());

                        Console.WriteLine("Введите размеры квадратного массива (n), который требуется вводить случайно, с возрастанием");
                        while (!int.TryParse(Console.ReadLine(), out n) || (n < 1))
                        {
                            Console.WriteLine("Неверный ввод. Введите натуральное число");
                        }
                        DT_array array_2 = new(n);
                        array_2.RandomFill();
                        Console.WriteLine(array_2.ToString());

                        Console.WriteLine("Введите размеры квадратного массива (n), который требуется заполнить простыми числами");
                        while (!int.TryParse(Console.ReadLine(), out n) || (n < 1))
                        {
                            Console.WriteLine("Неверный ввод. Введите натуральное число");
                        }
                        DT_array array_3 = new(n);
                        array_3.SimpleFill();
                        Console.WriteLine(array_3.ToString());

                        break;
                    }
                case 2:
                    {
                        int n = 0;
                        int m = 0;
                        Console.WriteLine("Введите количество школьников");
                        while (!int.TryParse(Console.ReadLine(), out m) || (m < 1))
                        {
                            Console.WriteLine("Неверный ввод. Введите натуральное число");
                        }
                        Console.WriteLine("Введите количество оценок");
                        while (!int.TryParse(Console.ReadLine(), out n) || (n < 1))
                        {
                            Console.WriteLine("Неверный ввод. Введите натуральное число");
                        }
                        DT_array school_array = new(m, n);
                        school_array.MarksFill();
                        school_array.MarksOut();
                        school_array.MarksCount(4.5);
                        break;
                    }
                case 3: 
                    {
                        int n = 0;
                        Console.WriteLine("Введите размеры квадратной матрицы A (n)");
                        while (!int.TryParse(Console.ReadLine(), out n) || (n < 1))
                        {
                            Console.WriteLine("Неверный ввод. Введите натуральное число");
                        }
                        DT_array array_A = new(n);
                        array_A.ManualFill();

                        Console.WriteLine("Введите размеры квадратной матрицы B (n)");
                        while (!int.TryParse(Console.ReadLine(), out n) || (n < 1))
                        {
                            Console.WriteLine("Неверный ввод. Введите натуральное число");
                        }
                        DT_array array_B = new(n);
                        array_B.ManualFill();

                        Console.WriteLine("Введите размеры квадратной матрицы C (n)");
                        while (!int.TryParse(Console.ReadLine(), out n) || (n < 1))
                        {
                            Console.WriteLine("Неверный ввод. Введите натуральное число");
                        }
                        DT_array array_C = new(n);
                        array_C.ManualFill();

                        Console.WriteLine("матрица A");
                        Console.WriteLine(array_A.ToString());
                        Console.WriteLine("матрица B");
                        Console.WriteLine(array_B.ToString());
                        Console.WriteLine("матрица C");
                        Console.WriteLine(array_C.ToString());

                        Console.WriteLine($"T(A) - T(B) + 2 * C = \n{array_A.T() - array_B.T() + 2 * array_C}");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Укажите название файла");
                        string path = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(path))
                        {
                            Console.WriteLine("Попробуйте снова");
                            path = Console.ReadLine();
                        }
                        FileClass.WriteBinary(path);
                        FileClass.ReadBinary(path);
                        FileClass.FindSquares(path);
                        break;
                    }
                case 5: 
                    {
                        Console.WriteLine("В разработке.");
                        break;
                    }
                case 6: 
                    {
                        Console.WriteLine("Укажите название файла");
                        string path = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(path))
                        {
                            Console.WriteLine("Попробуйте снова");
                            path = Console.ReadLine();
                        }
                        FileClass.FillFile(path);
                        FileClass.ShowFile(path);
                        Console.WriteLine($"Среднее арифметическое минимального и максимального значений {FileClass.FindAvg(path)}");
                        break;
                    }
                case 7: 
                    {
                        Console.WriteLine("Укажите название файла");
                        string path = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(path))
                        {
                            Console.WriteLine("Попробуйте снова");
                            path = Console.ReadLine();
                        }
                        FileClass.MakeFile(path);
                        FileClass.ShowFileStrings(path);
                        FileClass.CountMultiplication(path);
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("Укажите название файла (используется for_task_8.txt)");
                        string path = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(path))
                        {
                            Console.WriteLine("Попробуйте снова");
                            path = Console.ReadLine();
                        }
                        FileClass.ShowFileStrings(path);
                        FileClass.ExcludeLatin(path, "output.txt");
                        Console.WriteLine("Строки без латинских букв");
                        FileClass.ShowFileStrings("output.txt");
                        break;
                    }
                default:
                    {
                        if (option != 0)
                        {
                            Console.WriteLine("Неверный ввод");
                        }
                        break;
                    }
                    
            }

        }
    }
}