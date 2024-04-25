using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Project.Models
{
    internal class Cinema
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string hoursOfOperation { get; set; }
        public int numberRooms { get; set; }
        public User? owner { get; set; }
        public string type { get; set; }
        public string city   { get; set; }
        public int[] AnavibleMovies { get; set; }
        public bool isActive { get; set; }


    }
}
