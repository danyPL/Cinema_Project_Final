using Cinema_Project.Models;
using Cinema_Project.Scripts.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Project.Gui
{
    internal class CinemaView
    {
        public CinemaView()
        {
            Cinema_Actions cinema_Actions = new Cinema_Actions();
            Movie_Actions movie_Actions = new Movie_Actions();
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Witaj! Oto lista obecnie dostępnych kin:");
            Console.ResetColor();
            Console.WriteLine("\nUżyj strzałki w górę lub dół, aby wybrać opcję, a następnie zatwierdź klawiszem Enter:");

            var option = 1;
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Witaj! Oto lista obecnie dostępnych kin:");
                Console.ResetColor();

                for (int i = 0; i < cinema_Actions.cinemas.Count; i++)
                {
                    var cinema = cinema_Actions.cinemas[i];
                    var decorator = (i + 1 == option) ? "> \u001b[32m" : "   ";
                    Console.WriteLine($"{decorator}Kino: {cinema.name} Użytkownika: {cinema.owner.Name}\u001b[0m");
                }

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = (option == 1) ? cinema_Actions.cinemas.Count : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = (option == cinema_Actions.cinemas.Count) ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }

            switch (option)
             {
                 case 1:
                     Cinema c = cinema_Actions.cinemas[option - 1];
                    Console.Clear();
                    Console.WriteLine("Informacje dot. wybranego kina");
                    Console.WriteLine("--------------------------");
                     Console.WriteLine($"ID:{c.id}");
                    Console.WriteLine($"Nazwa:{c.name}");
                    Console.WriteLine($"Adres:{c.address}");
                    Console.WriteLine($"Lokalizacja:{c.city}");
                    Console.WriteLine($"Email:{c.email}");
                    Console.WriteLine($"Godziny otwarcia:{c.hoursOfOperation}");
                    Console.WriteLine($"Liczba dostępnych sal:{c.numberRooms}");
                    Console.WriteLine($"Typ ekranu:{c.type}");
                    Console.WriteLine($"Wlasciciel: {c.owner.Name}");
                    Console.WriteLine($"Dostepne filmy:");
                    
                    foreach(int s in c.AnavibleMovies)
                    {

                        Console.WriteLine(movie_Actions.GetMovieById(s).name);
                    }
                    break;
             }
            Console.ReadKey(true);
        }
    }
}
