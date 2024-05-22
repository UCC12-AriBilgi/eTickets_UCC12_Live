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

        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Logo gereklidir..")]
        public string? Logo { get; set; }

        [Display(Name = "Cinema Name")] // View ekranında gözükecek olan text bilgi
        [Required(ErrorMessage = "Cinema Name gerekli bilgidir..")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Cinema Name 2-50 karakter arasında olmalıdır...")]
        public string? Name { get; set; } // Cinema adı

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description bilgisi gereklidir..")]
        public string? Description { get; set; } 

        // Relations

        public List<Movie>? Movies { get; set; } // Şu an Movie tablosuna bağlantı kuruldu. Bir cinemada birçok film oynayabilir
    }
}
