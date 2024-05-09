using eTickets.Data.Base;
using eTickets.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; } // Bilet fiyatı

        public string ImageURL { get; set; } // Filmin afişi

        public DateTime StartDate { get; set; } // Vizyona giriş tarihi

        public DateTime EndDate { get; set; } // Vizyondan kalkış tarihi

        // Film türü için
        public MovieCategory movieCategory { get; set; }

        // Relations (One-to-Many)
        // Cinema

        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")] // Cinema modeliyle ilişkide olduğu belirtiyoruz.
        public Cinema Cinema { get; set; }

        // Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")] // Producer modeliyle ilişkide olduğunu belirtiyoruz.
        public Producer Producer { get; set; }

        // Relations (Many-to-Many)
        public List<Actor_Movie> Actors_Movies { get; set; }

        

    }
}
