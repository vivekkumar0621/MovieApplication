using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Model
{
    public class MovieDetails
    {
        public string MovieName { get; set; }
        public string DateOfRelease { get; set; }
        public List<String> actorsName { get; set; }
        public string ProducerName { get; set; }
        public string Plot { get; set; }
        public Poster poster { get; set; }
    }
}
