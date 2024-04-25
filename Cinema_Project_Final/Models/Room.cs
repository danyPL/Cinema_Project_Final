using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Project.Models
{
    internal class Room
    {
        public int id { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public int available_seats { get; set; }
        public bool is_taken { get; set; }
        public List<Seat> seats { get; set; }
        public int cols {  get; set; }
        public int rows { get; set; }
        public Movie? currentMovie { get; set; }

    }
}
