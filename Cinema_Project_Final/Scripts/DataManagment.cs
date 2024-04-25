using Cinema_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cinema_Project.Scripts
{
    abstract class DataManagment : Paths, IDataManagement
    {
        public List<User>? users;
        public List<Room>? rooms;
        public List<Movie>? movies;
        public List<Cinema>? cinemas;

        public virtual void LoadData()
        {
            string users_J = File.ReadAllText(PathUsers);
            string cinemas_J = File.ReadAllText(PathCinemas);
            string movies_J = File.ReadAllText(PathMovies);
            string rooms_J = File.ReadAllText(PathRooms);

            users = JsonSerializer.Deserialize<List<User>>(users_J);
            cinemas = JsonSerializer.Deserialize<List<Cinema>>(cinemas_J);
            movies = JsonSerializer.Deserialize<List<Movie>>(movies_J);
            rooms = JsonSerializer.Deserialize<List<Room>>(rooms_J);
        }

        public virtual void PushData(object data, ActionTypes type)
        {
            switch (type)
            {
                case ActionTypes.User:
                    users = (List<User>)data;
                    string jsonU = JsonSerializer.Serialize(users);
                    File.WriteAllText(PathUsers, jsonU);
                    break;
                case ActionTypes.Room:
                    rooms = (List<Room>)data;
                    string jsonR = JsonSerializer.Serialize(rooms);
                    File.WriteAllText(PathRooms, jsonR);
                    break;
                case ActionTypes.Movie:
                    movies = (List<Movie>)data;
                    string jsonM = JsonSerializer.Serialize(movies);
                    File.WriteAllText(PathMovies, jsonM);
                    break;
                case ActionTypes.Cinema:
                    cinemas = (List<Cinema>)data;
                    string jsonC = JsonSerializer.Serialize(cinemas);
                    File.WriteAllText(PathCinemas, jsonC);
                    break;
                default:
                    throw new ArgumentException("Invalid data type.");
            }
        }
    }
}