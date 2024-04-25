using Cinema_Project.Models;
using Cinema_Project.Scripts.Actions;
using System;
using System.Linq;

namespace Cinema_Project.Gui
{
    internal class AdminVIew
    {
        User owner = new User();
        Cinema_Actions cinema_actions = new();
        Movie_Actions movie_actions = new();
        Room_Actions room_actions = new();
        bool repeat = true;
        public AdminVIew(User owner)
        {
            this.owner = owner;
        }

        public void CreateCinema()
        {
            Console.Clear();
            string name, address, phoneNumber, email, hourOfOperation, type, city;
            int numberRooms;
            int[] AnviableMovies;
            Console.WriteLine("------------------------");
            Console.WriteLine("Witaj w kreatorze kina!");
            Console.WriteLine("------------------------");

            Console.WriteLine("Podaj nazwe kina:");
            name = Console.ReadLine();
            Console.WriteLine("Podaj adres kina:");
            address = Console.ReadLine();
            Console.WriteLine("Podaj numer telfeonu do kina:");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Podaj email kina:");
            email = Console.ReadLine();
            Console.WriteLine("Podaj godziny działania kina :");
            hourOfOperation = Console.ReadLine();
            Console.WriteLine("Podaj ilość pokoi w kinie:");
            numberRooms = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj typ ekranu w kinie:");
            type = Console.ReadLine();
            Console.WriteLine("Podaj miasto gdzie znajduje sie kino:");
            city = Console.ReadLine();
            Console.WriteLine("Podaj dostepne filmy w kinie używając id (podane id są podane w pliku movies.json):");
            string[] temp = Console.ReadLine().Split(",");
            AnviableMovies = Array.ConvertAll(temp, int.Parse);
            cinema_actions.CreateCinema(name, address, phoneNumber, email, hourOfOperation, numberRooms, owner, type, city, AnviableMovies);
        }

        public void RemoveCinema()
        {
            int CinemaID;
            Console.WriteLine("Podaj id kina, które chcesz usunąć:");
            CinemaID = Convert.ToInt32(Console.ReadLine());
            cinema_actions.RemoveCinema(CinemaID);
        }

        public void CreateMovie()
        {
            int film_uuid, year;
            string name, director, genre, image_url, description;
            double rating, ticketPrice;
            Console.WriteLine("Podaj unikalny identyfikator dla filmu:");
            film_uuid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj nazwę filmu:");
            name = Console.ReadLine();
            Console.WriteLine("Podaj twórcę filmu:");
            director = Console.ReadLine();
            Console.WriteLine("Podaj rok stworzenia filmu:");
            year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj średnią ocenę filmu:");
            rating = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj gatunek filmu:");
            genre = Console.ReadLine();
            Console.WriteLine("Podaj ścieżkę do obrazka dla filmu:");
            image_url = Console.ReadLine();
            Console.WriteLine("Podaj opis filmu:");
            description = Console.ReadLine();
            Console.WriteLine("Podaj cenę biletu na film:");
            ticketPrice = Convert.ToDouble(Console.ReadLine());
            movie_actions.CreateMovie(film_uuid, name, director, year, rating, genre, image_url, description, ticketPrice);
        }

        public void RemoveMovie()
        {
            int movieID;
            Console.WriteLine("Podaj id filmu, który chcesz usunąć:");
            movieID = Convert.ToInt32(Console.ReadLine());
            movie_actions.RemoveMovie(movieID);
        }

        public void CreateRoom()
        {
            Console.WriteLine("Podaj nazwę sali:");
            string name = Console.ReadLine();

            Console.WriteLine("Podaj pojemność sali:");
            int capacity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj dostępną liczbę miejsc:");
            int availableSeats = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Czy sala jest zajęta? (true/false):");
            bool isTaken = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Podaj liczbę kolumn:");
            int cols = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj liczbę rzędów:");
            int rows = Convert.ToInt32(Console.ReadLine());

            // Current movie
            Console.WriteLine("Czy aktualnie wyświetlany jest jakiś film? (true/false):");
            bool isCurrentMovie = Convert.ToBoolean(Console.ReadLine());
            Movie? currentMovie = null;
            if (isCurrentMovie)
            {
                Console.WriteLine("Podaj id aktualnie wyświetlanego filmu:");
                int movieId = Convert.ToInt32(Console.ReadLine());
                currentMovie = movie_actions.GetMovieById(movieId);
            }

            room_actions.CreateRoom(name, capacity, availableSeats, isTaken, cols, rows, currentMovie);
        }

        public void RemoveRoom()
        {
            int roomID;
            Console.WriteLine("Podaj id pokoju, który chcesz usunąć:");
            roomID = Convert.ToInt32(Console.ReadLine());
            room_actions.RemoveRoom(roomID);
        }
    }
}