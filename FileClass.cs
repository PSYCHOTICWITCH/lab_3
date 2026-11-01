using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab_3
{
    internal class FileClass
    {
        public static void WriteBinary(string path)
        {
            using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            using var bw = new BinaryWriter(fs);
            int amount = 0;
            Random rand = new Random();
            Console.WriteLine("Введите количество чисел, которые требуется записать в файл");
            while (!int.TryParse(Console.ReadLine(), out amount) || amount < 1)
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова");
            }
            for (int i = 0; i < amount; i++) 
            { 
                bw.Write(rand.Next(1, 10000));
            }

        }

        public static void ReadBinary(string path) 
        {
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using var br = new BinaryReader(fs);

            Console.WriteLine("Данные бинарного файла:");
            while (fs.Position < fs.Length) 
            {
                Console.Write($"{br.ReadInt32()} ");
            }
            Console.Write("\n");
        }

        public static void FindSquares(string path)
        {
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            using var br = new BinaryReader(fs);
            double element = 0;
            bool found = false;
            Console.WriteLine("Список квадратов нечетных чисел из файла:");
            while (fs.Position < fs.Length)
            {
                element = br.ReadInt32();
                if (Math.Sqrt(element) == (int)Math.Sqrt(element) && element % 2 == 1)
                {
                    found = true;
                    Console.WriteLine($"{element} - {(int)Math.Sqrt(element)}");
                }
            }
            if (!found) 
            {
                Console.WriteLine("Значения не найдены");
            }
        }

        public static void FillFile(string path)
        {
            Random rand = new Random();
            int amount = 0;
            Console.WriteLine("Введите количество чисел, которые требуется записать в файл");
            while (!int.TryParse(Console.ReadLine(), out amount) || amount < 1)
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова");
            }
            using (StreamWriter sw = new StreamWriter(path)) 
            {
                for (int i = 0; i < amount; i++)
                {
                    sw.WriteLine(rand.Next(10000).ToString());
                }
            }
            
        }

        public static void ShowFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Console.WriteLine("Данные из файла:");
            foreach (string line in lines)
            {
                Console.Write($"{line} ");
            }
            Console.Write("\n");
        }

        public static void ShowFileStrings(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Console.WriteLine("Данные из файла:");
            foreach (string line in lines)
            {
                Console.WriteLine($"{line}");
            }
            Console.Write("\n");
        }

        public static double FindAvg(string path) 
        {
            string[] lines = File.ReadAllLines(path);
            int number = 0;
            int minimum = 10000;
            int maximum = 0;
            foreach (string line in lines) 
            { 
                if (int.TryParse(line, out number))
                {
                    if (number < minimum)
                    {
                        minimum = number;
                    }
                    if (number > maximum)
                    {
                        maximum = number;
                    }
                }
            }
            return (maximum + minimum) / 2.0;
        }

        public static void MakeFile(string path) 
        {
            Random rand = new Random();
            int amount_rows = rand.Next(1, 10);
            int amount_ints = 0;
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < amount_rows; i++)
                {
                    amount_ints = rand.Next(1, 10);
                    for (int j = 0; j < amount_ints; j++)
                    {
                        sw.Write($"{rand.Next(100).ToString()} ");
                    }
                    sw.Write("\n");
                }
                
            }
        }

        public static void CountMultiplication(string path)
        {
            string[] lines = File.ReadAllLines(path);
            BigInteger multiplication = 1;
            bool was_multiply = false;
            foreach (string line in lines)
            {
                foreach (string symbol in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    int number = 0;
                    if (int.TryParse(symbol, out number) && number % 2 == 0 && number != 0)
                    {
                        was_multiply = true;
                        multiplication *= number;
                    }
                }
                
            }
            if (!was_multiply)
            {
                Console.WriteLine("Четных чисел не обнаружено");
            }
            else
            {
                Console.WriteLine($"Произведение четных чисел - {multiplication}");
            }
        }

        public static void ExcludeLatin(string path, string output_path)
        {
            string[] lines = File.ReadAllLines(path);
            bool has_latin = false;
            using (StreamWriter sw = new StreamWriter(output_path))
            {
                foreach (string line in lines)
                {
                    has_latin = false;
                    foreach (char c in line)
                    {
                        if ((c >= 'a') && (c <= 'z') || (c >= 'A') && (c <= 'Z'))
                        {
                            has_latin = true;
                            break;
                        }
                    }
                    if (!has_latin)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
        }

        public static void FillToysFile(string path)
        {
            ToyList data = new ToyList
            {
                Items = new Toy[]
                {
                    new Toy { Name = "Плюшевый мишка", Price = 800m, MinAge = 1, MaxAge = 2 },
                    new Toy { Name = "Кукла", Price = 1500m, MinAge = 3, MaxAge = 5 },
                    new Toy { Name = "Машинка", Price = 400m, MinAge = 2, MaxAge = 10 },
                    new Toy { Name = "Конструктор", Price = 2000m, MinAge = 5, MaxAge = 12 },
                    new Toy { Name = "Мяч", Price = 500m, MinAge = 1, MaxAge = 10 },
                    new Toy { Name = "Пирамидка", Price = 400m, MinAge = 1, MaxAge = 3 },
                    new Toy { Name = "Кубики", Price = 700m, MinAge = 2, MaxAge = 4 },
                    new Toy { Name = "Пазл 1000 дет.", Price = 800m, MinAge = 5, MaxAge = 13 },
                    new Toy { Name = "Кролик плюшевый", Price = 1000m, MinAge = 2, MaxAge = 3 },
                    new Toy { Name = "Пони", Price = 3000m, MinAge = 5, MaxAge = 10 },
                }

            };
            XmlSerializer serializer = new XmlSerializer(typeof(ToyList));
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, data);
            }

        }

        public static void ShowXml(string path)
        {
            Toy[] toys = null;
            XmlSerializer serializer = new XmlSerializer(typeof(ToyList));
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                ToyList data = (ToyList)serializer.Deserialize(fs);
                toys = data.Items;
            }
            Console.WriteLine("\nВсе игрушки в файле:");
            foreach (var t in toys)
                Console.WriteLine("  " + t);
        }

        public static void FindExpensive(string path)
        {
            Toy[] toys = null;
            XmlSerializer serializer = new XmlSerializer (typeof(ToyList));
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                ToyList data = (ToyList)serializer.Deserialize(fs);
                toys = data.Items;
            }

            Toy expensive_toy = toys[0];
            int max_price = 0;
            bool toy_found = false;
            foreach (var t in toys)
            {
                if (t.MinAge < 4)
                {
                    if (t.Price > max_price)
                    {
                        expensive_toy = t;
                        toy_found = true;
                    }
                }             
                    
            }

            Console.WriteLine("\nРезультат:");
            if (!toy_found)
            {
                Console.WriteLine("Игрушек для детей до 4 лет не найдено.");
            }
            else
            {
                Console.WriteLine("Самая дорогая игрушка для детей до 4 лет:");
                Console.WriteLine($"  {expensive_toy.Name} — {expensive_toy.Price} руб. " +
                                  $"(возраст: {expensive_toy.MinAge}-{expensive_toy.MaxAge} лет)");
            }
        }

    }
}
