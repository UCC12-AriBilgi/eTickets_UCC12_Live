using eTickets.Models;

namespace eTickets.ViewModels
{
    // Secenekli olan yerlerde (Add) bana listeler sunacak.

    public class NewMovieDropdownsVM
    {
        // Değişgenler

        // Producer listesi için
        public List<Producer> Producers { get; set; }

        // Actor Listesi için
        public List<Actor> Actors { get; set; }

        // Cinema Listesi için
        public List<Cinema> Cinemas { get; set;}

        // constructor
        public NewMovieDropdownsVM()
        {
            Actors = new List<Actor>();
            Cinemas= new List<Cinema>();
            Producers= new List<Producer>();
        }

    }
}
