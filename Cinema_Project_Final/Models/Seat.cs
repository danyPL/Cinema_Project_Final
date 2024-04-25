using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Project.Models
{
    internal class Seat
    {
        public int number { get; set; }
        public bool is_taken { get; set; }
        public User? user { get; set; }
    }
}
