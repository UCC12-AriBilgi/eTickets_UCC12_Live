using eTickets.Models;

namespace eTickets.ViewModels
{
    // Secenekli olan yerlerde (Add) bana listeler sunacak.
    // Yeni movie yaratma ekranında yer alacak dropdownlar için

    public class NewMovieDropdownsVM
    {
        // Değişgenler

        // Producer listesi için
        public List<Producer> Producers { get; set; } // Producer dd için

        // Actor Listesi için
        public List<Actor> Actors { get; set; } // Actor dd için

        // Cinema Listesi için
        public List<Cinema> Cinemas { get; set;} // Cinema dd için

        // constructor
        public NewMovieDropdownsVM()
        {
            Actors = new List<Actor>();

            Cinemas= new List<Cinema>();
            
            Producers= new List<Producer>();
        }

    }
}
