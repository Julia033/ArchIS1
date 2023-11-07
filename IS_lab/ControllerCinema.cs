using System;
using System.Collections.Generic;
using System.IO;

namespace IS_lab
{
    public class ControllerCinema
    {
        private string filePath;
        private List<Cinema> movies;

        public ControllerCinema(string filePath)
        {
            this.filePath = filePath;
            movies = Cinema.ReadCinemaFromCSV(filePath);
        }


        public void DisplayAllData()
        {
            if (movies.Count > 0)
            {
                int i = 0;
                foreach (Cinema cinema in movies)
                {
                    Console.WriteLine("Все записи:");
                    Console.WriteLine("\nЗапись " + (i + 1));
                    Console.WriteLine($"Название фильма: {cinema.Name}");
                    Console.WriteLine($"Дата и время: {cinema.Datetime}");
                    Console.WriteLine($"Наличие свободных мест: {cinema.Available_seats}");
                    Console.WriteLine($"Количество свободных мест: {cinema.Total_seats}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Нет записей");
            }
        }
        public void DisplayByNumber(int stringnumber)
        {
            if (stringnumber >= 1 && stringnumber <= movies.Count)
            {
                Cinema cinema = movies[stringnumber - 1];
                Console.WriteLine($"Название фильма: {cinema.Name}");
                Console.WriteLine($"Дата и время: {cinema.Datetime}");
                Console.WriteLine($"Наличие свободных мест: {cinema.Available_seats}");
                Console.WriteLine($"Количество свободных мест: {cinema.Total_seats}");
            }
            else
            {
                Console.WriteLine("Нет записи с таким номером");
            }
        }
        public void AddRecord(string name, string datetime, bool available_seats, int total_seats)
        {
            Cinema cinema = new Cinema(name, datetime, available_seats, total_seats);
            movies.Add(cinema);
            SaveDataToCSV();
            Console.WriteLine("Запись добавлена");

        }
        private void SaveDataToCSV()
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Название фильма,Дата и время сеанса,Наличие свободных мест,Количество свободных мест");
                foreach (Cinema cinema in movies)
                {
                    writer.WriteLine(cinema.Name + "," + cinema.Datetime + "," + cinema.Available_seats + "," + cinema.Total_seats);
                }
            }
        }
        public void DeleteRecord(int stringnumber)
        {
            if (stringnumber >= 1 && stringnumber <= movies.Count)
            {
                movies.RemoveAt(stringnumber - 1);
                SaveDataToCSV();
                Console.WriteLine("Запись удалена");
            }
        }

       

    }

}

