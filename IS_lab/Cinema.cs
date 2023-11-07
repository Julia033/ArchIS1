using System;
using System.Collections.Generic;
using System.IO;



namespace IS_lab
{
    public sealed class Cinema
    {
        public string Name { get; set; }
        public string Datetime { get; set; }
        public bool Available_seats { get; set; }
        public int Total_seats { get; set; }

        public Cinema (string name, string datetime, bool available_seats, int total_seats)
        {
            Name = name;
            Datetime = datetime;
            Available_seats = available_seats;
            Total_seats = total_seats;
        }

        public static List<Cinema> ReadCinemaFromCSV(string filePath)
        {
            List<Cinema> movies = new List<Cinema>();

            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var row = reader.ReadLine().Split(',');
                    string name = row[0];
                    string datetime = row[1];
                    bool.TryParse(row[2], out bool available_seats);
                    int total_seats = int.Parse(row[3]);
                    Cinema cinema = new Cinema(name, datetime, available_seats, total_seats);
                    movies.Add(cinema);
                }
            }
            return movies;
        }
        public void Display()
        {
            Console.WriteLine("\nНазвание фильма: " + Name);
            Console.WriteLine("Дата и время сеанса: " + Datetime);
            Console.WriteLine("Наличие свободных мест: " + Available_seats);
            Console.WriteLine("Количество свободных мест: " + Total_seats);
        }
    }

  
}

