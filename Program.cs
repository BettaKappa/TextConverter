using Newtonsoft.Json;
using System.Xml.Serialization;

namespace AAAAAAAAAAAAAAAAAAAAAAAAAA
{
    internal class Program
    {

        public static void Main()
        {
            Bus number260 = new();
            {
                number260._Number_ = 260;
                number260.Location = "Близко";
                number260.Time_min = 7;
                number260.Fullness = "Вероятно, селёдка в банке чувсвует себя комфортнее";
            }

            Bus number107 = new();
            {
                number107._Number_ = 107;
                number107.Location = "Далеко";
                number107.Time_min = 5;
                number107.Fullness = "Жить можно";
            }

            Bus number209 = new();
            {
                number209._Number_ = 209;
                number209.Location = "Близко";
                number209.Time_min = 10;
                number209.Fullness = "Очки запотевают моментально";
            }
            List<Bus> buses = new() { number260, number107, number209 };

            ShowMenu(buses, number260, number107, number209 );

        }
        public static void ShowMenu(List<Bus> buses, Bus number260, Bus number107, Bus number209)
        {
            int position = 0;
            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("   Сереализовать ");
                Console.WriteLine("   Десереализовать ");
                Arrow(key, position);
                key = Console.ReadKey();
            }
            Console.Clear();

            switch (position)
            {
                case 0:
                    //Пробел
                    ShowSerealizeMenu( buses, number260, number107, number209);
                    break;
                case 1:
                    //Пробел
                    //ShowDeserealizeMenu();
                    break;
            }
            
        }

        private static void ShowSerealizeMenu( List<Bus> buses, Bus number260, Bus number107, Bus number209)
        {
            int position = 0;
            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("   .xml ");
                Console.WriteLine("   .json ");
                Console.WriteLine("   .txt ");
                Arrow(key, position);
                key = Console.ReadKey();
            }
            Console.Clear();

            switch (position)
            {
                case 0:
                    SeXml(buses);
                    break;
                case 1:
                    SeJson(buses);
                    break;
                case 2:
                    SeTxt(number260, number107, number209);
                    break;
            }

        }

        private static void SeTxt(Bus number260, Bus number107, Bus number209)
        {
            string bus260 = number260._Number_ + "\n" + number260.Location + "\n" + number260.Time_min + " мин\n" + number260.Fullness + "\n\n";
            string bus107 = number107._Number_ + "\n" + number107.Location + "\n" + number107.Time_min + " мин\n" + number107.Fullness + "\n\n";
            string bus209 = number209._Number_ + "\n" + number209.Location + "\n" + number209.Time_min + " мин\n" + number209.Fullness + "\n\n";

            List<string> buses = new() { bus260, bus107, bus209 };

            File.AppendAllLines("C:\\Users\\xenia\\Desktop\\Buses.txt", buses);
        }

        private static void SeJson(List<Bus> buses)
        {
            string json = JsonConvert.SerializeObject(buses);

            File.WriteAllText("C:\\Users\\xenia\\Desktop\\Buses.json", json);
        }

        public static void SeXml(List<Bus> buses)
        {
            XmlSerializer xml = new(typeof(List<Bus>));

            using FileStream fs = new("C:\\Users\\xenia\\Desktop\\Buses.xml", FileMode.Create);

            xml.Serialize(fs, buses);
        }

        private static void Arrow(ConsoleKeyInfo key, int position)
        {
            Console.CursorVisible = false;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    position--;
                    break;
                case ConsoleKey.DownArrow:
                    position++;
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.WriteLine("Вы вышли");
                    Environment.Exit(Environment.ExitCode);
                    break;
            }

            Console.SetCursorPosition(0, position);
            Console.WriteLine(" ► ");
        }
    }
}