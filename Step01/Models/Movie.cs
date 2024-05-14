using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double? Price { get; set; }

        public string? ImageURL { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public MovieCategory? movieCategory { get; set; }

        //Relations Notes- Step01.7.1
        //(Many to Many)
        public List<Actor_Movie>? Actors_Movies { get; set; }

        //Cinema
        // One to Many
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")] // Hangi field ile bağlı olduğunu belirtiyoruz
        public Cinema? Cinema { get; set; }

        //Producer
        // One to Many
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")] // Hangi field ile bağlı olduğunu belirtiyoruz
        public Producer? Producer { get; set; }
    }
}
