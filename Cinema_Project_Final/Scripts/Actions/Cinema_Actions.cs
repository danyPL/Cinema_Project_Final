using Cinema_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cinema_Project.Scripts.Actions
{
    internal class Cinema_Actions:DataManagment
    {
        public Cinema_Actions() {
            LoadData();
        }
       public void CreateCinema(
           string name,
           string address,
           string phoneNumber,
           string email,
           string hoursOfOperation,
           int numberRooms,
           User owner,
           string type,
           string city,
           int[] AnviableMovies
           )
        {
            // tworzenie nowego kina
            Cinema newCinema = new()
            {
                id = cinemas.Count + 1,
                name = name,
                address = address,
                phoneNumber = phoneNumber,
                email = email,
                hoursOfOperation = hoursOfOperation,
                numberRooms = numberRooms,
                owner = owner,
                type = type,
                city = city,
                AnavibleMovies = AnviableMovies,
                isActive = true
            };
            cinemas.Add(newCinema);

            PushData(cinemas,ActionTypes.Cinema);
        }

        public  void RemoveCinema(int id)
        {
            Cinema RemoveCinema = cinemas.FirstOrDefault(c => c.id == id);

            if (RemoveCinema != null)
            {
                cinemas.Remove(RemoveCinema);
                PushData(cinemas, ActionTypes.Cinema);
            }
            else
            {
                Console.WriteLine("Cinema not found.");
            }
        }

        public  void EditCinema(int id, Cinema Edit_C)
        {
            Cinema cinemaToEdit = cinemas.FirstOrDefault(c => c.id == id);

            if (cinemaToEdit != null)
            {
                cinemaToEdit = Edit_C;

                PushData(cinemas, ActionTypes.Cinema);
            }
            else
            {
                Console.WriteLine("Cinema not found.");
            }
        }
        public Cinema CheckCinema(int id)
        {
            return cinemas[id];
        }
    }
}
