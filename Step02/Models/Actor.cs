using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        // (17.1)
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture gereklidir.")]
        public string? ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Tam ad gereklidir.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ad 3-50 karakter arasında olmalıdır..")]
        public string? FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biografi bilgisi gereklidir.")]
        public string? Bio { get; set; }

        //Relations
        public List<Actor_Movie>? Actors_Movies { get; set; } // Bir Actor çok Movie de oynayabilir
    }
}
