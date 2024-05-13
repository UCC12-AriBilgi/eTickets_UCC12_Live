using eTickets.Models;

namespace eTickets.Data.ViewModels
{
    // Movie viewlarında gözükecek dropdown(çoktan seçmeli) ayarlamaları

    public class NewMovieDropdownsVM
    {
        // Değişgenler
        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }

        // constructor
        public NewMovieDropdownsVM()
        {
            Producers = new List<Producer>();
            Cinemas= new List<Cinema>();
            Actors = new List<Actor>();
        }

    }
}
