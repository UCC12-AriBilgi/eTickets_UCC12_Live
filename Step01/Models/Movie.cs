using eTickets.Data.Enum;

namespace eTickets.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; } // Bilet fiyatı

        public string ImageURL { get; set; } // Filmin afişi

        public DateTime StartDate { get; set; } // Vizyona giriş tarihi

        public DateTime EndDate { get; set; } // Vizyondan kalkış tarihi

        // Film türü için
        public MovieCategory movieCategory { get; set; }
        

    }
}
