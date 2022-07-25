using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Model
{
    public class MovieInfo
    {
        public string MovieName { get; set; }
        public string Plot { get; set; }
        public string DateOfRelease { get; set; }
        public List<int> ActorsID { get; set; }
        public int PID { get; set; }
        public FileInfo file { get; set; }
    }
}
