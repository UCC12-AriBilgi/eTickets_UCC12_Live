using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    // Cinema bilgilerini tutacak class

    // (29)
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string? Logo { get; set; }

        public string? Name { get; set; } // Cinema adı

        public string? Description { get; set; } 

        // Relations

        public List<Movie>? Movies { get; set; } // Şu an Movie tablosuna bağlantı kuruldu. Bir cinemada birçok film oynayabilir
    }
}
