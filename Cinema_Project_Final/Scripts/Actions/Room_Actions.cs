using Cinema_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Project.Scripts.Actions
{
    internal class Room_Actions : DataManagment
    {
        public Room_Actions()
        {
            LoadData();
        }
        public void CreateRoom(string name, int capacity, int available_seats, bool is_taken, int cols, int rows, Movie? currentmovie)
        {
            Room newRoom = new()
            {
                id = rooms.Count + 1,
                name = name,
                capacity = capacity,
                available_seats = available_seats,
                is_taken = is_taken,
                cols = cols,
                rows = rows,
                currentMovie = currentmovie
            };
            rooms.Add(newRoom);

            PushData(rooms, ActionTypes.Room);
        }
        public List<Seat> Get_Seats(int RoomID)
        {
            Room room = rooms.Find(e => e.id == RoomID);
            return room.seats;
        }
        public Room GetRoom(int RoomID)
        {
            Room room = rooms.Find(e => e.id == RoomID);
            return room;
        }

        public void Reservation(int roomId, int seatId, User user)
        {
            Room room = rooms.FirstOrDefault(r => r.id == roomId);
            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            Seat seat = room.seats.FirstOrDefault(s => s.number == seatId);
            if (seat == null)
            {
                Console.WriteLine("Seat not found.");
                return;
            }

            if (seat.is_taken)
            {
                Console.WriteLine("Seat is already taken.");
                return;
            }

            seat.is_taken = true;
            seat.user = user;
            room.available_seats -= 1;
            PushData(rooms, ActionTypes.Room);
        }

        public void Reservation_Cancel(int roomId, int seatId)
        {
            Room room = rooms.FirstOrDefault(r => r.id == roomId);
            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            Seat seat = room.seats.FirstOrDefault(s => s.number == seatId);
            if (seat == null)
            {
                Console.WriteLine("Seat not found.");
                return;
            }

            if (!seat.is_taken)
            {
                Console.WriteLine("Seat is not taken.");
                return;
            }

            seat.is_taken = false;
            seat.user = null;
            room.available_seats += 1;
            PushData(rooms, ActionTypes.Room);
        }
        public void RemoveRoom(int id)
        {
            Room RemoveRoom = rooms.FirstOrDefault(c => c.id == id);

            if (RemoveRoom != null)
            {
                rooms.Remove(RemoveRoom);
                PushData(rooms, ActionTypes.Room);
            }
            else
            {
                Console.WriteLine("Film nie znaleziony.");
            }
        }
        public Movie GetRoomMovie(int roomID)
        {
            Room room = rooms.FirstOrDefault(e => e.id == roomID);
            if (room != null && room.currentMovie != null)
            {
                Movie currentMovieName = movies.FirstOrDefault(e => e.film_uuid == room.currentMovie.film_uuid);
                return currentMovieName;
            }
            return null;
        }
    }
}