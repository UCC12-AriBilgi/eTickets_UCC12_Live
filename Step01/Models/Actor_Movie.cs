using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    // Many-to-Many relation için yaratılıyor (Junk-Join table)

    public class Actor_Movie
    {
        public int MovieId { get; set; }
        public Movie? Movie { get; set; } // Movie modelinden gelecek bilgi için

        public int ActorId { get; set; }
        public Actor? Actor { get; set; } // Actor modelinden gelecek bilgi için
    }
}
