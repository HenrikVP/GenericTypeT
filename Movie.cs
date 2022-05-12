using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypeT
{
    enum Genre { Horror, Scify }
    [Serializable]


    internal class Movie : Base
    {
        public Genre MovieGenre { get; set; }
        public DateTime Release { get; set; }
    }
}
