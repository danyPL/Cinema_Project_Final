using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Project.Models
{
    internal class Movie
    {
        public int id { get; set; }
        public int film_uuid { get; set; }
        public string name { get; set; }
        public string director { get; set; }
        public int year { get; set; }
        public double rating { get; set; }
        public string genre { get; set; }
        public string image_url {  get; set; }
        public string description { get; set; }
        public double ticketPrice  { get; set; }
    }
}
