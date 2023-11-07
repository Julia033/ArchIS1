using System;


namespace IS_lab
{
    class Program
    {
        static void Main()
        {
            string filePath = "lab10.csv";

            ControllerCinema cinemaController = new ControllerCinema(filePath);
            bool exit = false;
            do
            {
                Console.WriteLine("\n1. Вывести все записи");
                Console.WriteLine("2. Вывести запись по номеру");
                Console.WriteLine("3. Добавить запись в файл");
                Console.WriteLine("4. Удалить запись");
                Console.WriteLine("Esc. Выход");

                Console.Write("Выберите операцию: ");
                ConsoleKeyInfo userInput = Console.ReadKey();
                Console.WriteLine();

                switch (userInput.Key)
                {
                    case ConsoleKey.D1:
                        cinemaController.DisplayAllData();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Введите номер записи, которую необходимо вывести:");
                        int recordNumber;
                        if (int.TryParse(Console.ReadLine(), out recordNumber))
                        {
                            cinemaController.DisplayByNumber(recordNumber);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный формат числа");
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.Write("\nВведите название фильма: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите дату и время сеанса: ");
                        string datetime = Console.ReadLine();
                        Console.Write("Введите наличие свободных мест: ");
                        string check = Console.ReadLine();
                        int total_seats;
                        bool available_seats;
                        if (check == "да")
                        {
                            available_seats = true;
                            Console.Write("Введите количество свободных мест: ");
                            string check1 = Console.ReadLine();
                            if (int.TryParse(check1, out total_seats))
                            {
                                total_seats = int.Parse(check1); 
                            }
                            else
                            {
                                Console.WriteLine("Недопустимый выбор, попробуйте снова");
                                return;
                            }
                        }
                        else if (check == "нет")
                        {
                            available_seats = false;
                            total_seats = 0;
                        }
                        else
                        {
                            Console.WriteLine("Недопустимый выбор, попробуйте снова");
                            return;
                        }
                        cinemaController.AddRecord(name, datetime, available_seats, total_seats);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Введите номер записи, которую необходимо удалить:");
                        int recordNumberToDelete;
                        if (int.TryParse(Console.ReadLine(), out recordNumberToDelete))
                        {
                            cinemaController.DeleteRecord(recordNumberToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный формат числа");
                        }
                        Console.ReadLine();
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                }

            } while (!exit);
        }
    }
}