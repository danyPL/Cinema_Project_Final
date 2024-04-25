using Cinema_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Project.Scripts.Actions
{
    internal class Movie_Actions:DataManagment
    {
        public Movie_Actions() {
            LoadData();

        }
        public void CreateMovie(int film_uuid,string name,string director,int year, double rating,string genre,string image_url,string description,double ticketPrice)
        {
            Movie newMovie = new()
            {
                id = movies.Count + 1,
                film_uuid = film_uuid,
                name = name,
                director = director,
                year = year,
                rating = rating,
                genre = genre,
                image_url = image_url,
                description = description,
                ticketPrice = ticketPrice
            };
            movies.Add(newMovie);

            PushData(movies, ActionTypes.Movie);
        }
        public Movie GetMovieById(int id)
        {
            Movie movie = movies.FirstOrDefault(x => x.film_uuid == id);

            return movie;
        }
        public void RemoveMovie(int id)
        {
            Movie RemoveMovie = movies.FirstOrDefault(c => c.id == id);

            if (RemoveMovie != null)
            {
                movies.Remove(RemoveMovie);
                PushData(movies, ActionTypes.Movie);
            }
            else
            {
                Console.WriteLine("Film nie znaleziony.");
            }
        }

    }
}
