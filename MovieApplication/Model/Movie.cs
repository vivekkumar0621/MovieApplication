using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Model
{
    public class Movie
    {
        public int MID { get; set; }
        public string MovieName { get; set; }
        public string Plot { get; set; }
        public string DateOfRelease { get; set; }
        public int PID { get; set; }
        public int PosterID { get; set; }

    }
}
