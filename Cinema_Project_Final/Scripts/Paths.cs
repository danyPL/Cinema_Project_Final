using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Project.Scripts
{
    public abstract class Paths
    {
        protected string PathCinemas { get; private set; }
        protected string PathUsers { get; private set; }
        protected string PathMovies { get; private set; }
        protected string PathRooms { get; private set; }

        protected Paths()
        {
            PathCinemas = Path.Combine(Directory.GetCurrentDirectory(), "data","cinemas", "cinemas.json");
            PathUsers = Path.Combine(Directory.GetCurrentDirectory(), "data","users","users.json");
            PathMovies = Path.Combine(Directory.GetCurrentDirectory(), "data","movies","movies.json");
            PathRooms = Path.Combine(Directory.GetCurrentDirectory(), "data","rooms","rooms.json");
        }
    }
}
