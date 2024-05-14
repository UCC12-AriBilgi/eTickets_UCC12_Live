using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    // Actor bilgilerinin tutulacağı model(class)

    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength =3,ErrorMessage ="Full Name must include between 3 to 50 characters")]
        public string? FullName { get; set; }

        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage ="Profile Picture is required")]
        public string? ProfilePictureURL { get; set; }
        // direkt resim olarak tutmak yerine resmin bulunduğu yer olarak tutmak vt boyutu ve performansını artırmak için iyidir

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography info is required")]
        public string? Bio {  get; set; }

        // Relations
        public List<Actor_Movie>? Actors_Movies { get; set; } // Bir aktor birden fazla Movie de oynayabilir. 

    }
}
