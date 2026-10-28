using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab_3
{
    public struct Toy
    {
        public string Name;
        public int Price;
        public int minAge;
        public int maxAge;

        public Toy(string name, int price, int min_age, int max_age)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя обязательно", nameof(name));
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price));
            if (min_age < 0)
                throw new ArgumentOutOfRangeException(nameof(min_age));
            if (max_age < 0 && max_age < min_age)
                throw new ArgumentOutOfRangeException(nameof(max_age));
            Name = name;
            Price = price;
            minAge = min_age;
            maxAge = max_age;
        }
    }
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

        //public static Toy[] ToyList()
        //{
        //    string[] toyNames = new string[]
        //    {
        //        "Кукла",
        //        "Мишка плюшевый",
        //        "Зайчик",
        //        "Машинка",
        //        "Грузовик",
        //        "Самолёт",
        //        "Ракета",
        //        "Кораблик",
        //        "Поезд",
        //        "Робот",
        //        "Конструктор",
        //        "Кубики",
        //        "Пазл",
        //        "Мяч",
        //        "Скакалка",
        //        "Обруч",
        //        "Санки",
        //        "Самокат",
        //        "Велосипед",
        //        "Воздушный змей",
        //        "Юла",
        //        "Неваляшка",
        //        "Матрёшка",
        //        "Пирамидка",
        //        "Солдатик",
        //        "Динозавр",
        //        "Тигр",
        //        "Слон",
        //        "Лошадка",
        //        "Собачка",
        //        "Кошка",
        //        "Попугай",
        //        "Рыбка",
        //        "Черепаха",
        //        "Пингвин",
        //        "Лев",
        //        "Жираф",
        //        "Обезьянка",
        //        "Крокодил",
        //        "Ёжик",
        //        "Клоун",
        //        "Волчок",
        //        "Калейдоскоп",
        //        "Мозаика",
        //        "Домино",
        //        "Лото",
        //        "Шахматы",
        //        "Шашки",
        //        "Нарды",
        //        "Дартс",
        //        "Кегли",
        //        "Городки",
        //        "Свисток",
        //        "Барабан",
        //        "Дудочка",
        //        "Ксилофон",
        //        "Гитара детская",
        //        "Пианино детское",
        //        "Металлофон",
        //        "Набор доктора",
        //        "Набор повара",
        //        "Набор инструментов",
        //        "Набор художника",
        //        "Машинка пожарная",
        //        "Машинка полицейская",
        //        "Скорая помощь",
        //        "Экскаватор",
        //        "Бульдозер",
        //        "Подъёмный кран",
        //        "Трактор",
        //        "Танк",
        //        "Вертолёт",
        //        "Подводная лодка",
        //        "Лодка",
        //        "Паром",
        //        "Автобус",
        //        "Трамвай",
        //        "Метро",
        //        "Самосвал",
        //        "Бетономешалка",
        //        "Мотоцикл",
        //        "Квадрокоптер",
        //        "Волшебная палочка",
        //        "Кукольный домик",
        //        "Коляска для кукол",
        //        "Мебель для кукол",
        //        "Посуда для кукол",
        //        "Одежда для кукол",
        //        "Мягкий кот",
        //        "Мягкий пёс",
        //        "Мягкий слон",
        //        "Сова",
        //        "Лиса",
        //        "Ёжик лесной",
        //        "Пингвинёнок",
        //        "Тюлень",
        //        "Дельфин",
        //        "Кит",
        //        "Дракон",
        //        "Единорог",
        //        "Фея",
        //    };
        //    Random rand = new Random();
        //    int amount = 0;
        //    Console.WriteLine("Введите количество чисел, которые требуется записать в файл");
        //    while (!int.TryParse(Console.ReadLine(), out amount) || amount < 1)
        //    {
        //        Console.WriteLine("Неверный ввод. Попробуйте снова");
        //    }

        //    Toy[] toys = new Toy[amount];

        //    for (int i = 0; i < amount; i++)
        //    {
        //        toys[i].Name = toyNames[rand.Next(toyNames.Length)];
        //        toys[i].Price = rand.Next(10, 10000);
        //        toys[i].minAge = rand.Next(0, 13);
        //        toys[i].maxAge = rand.Next(toys[i].minAge, 20);
        //    }

        //    return toys;
        //}

        //public static string ToXml(Toy[] toys)
        //{
        //    var ser = new XmlSerializer(typeof(Toy[]));
        //    using var sw = new StringWriter();
        //    ser.Serialize(sw, toys);
        //    return sw.ToString();
        //}

        //public static Toy[] FromXml(string xml)
        //{
        //    var ser = new XmlSerializer(typeof(Toy[]));
        //    using var sr = new StringReader(xml);
        //    return (Toy[])ser.Deserialize(sr)!;
        //}


    }
}
