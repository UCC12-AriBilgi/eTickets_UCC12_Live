using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    // Actor bilgilerinin tutulacağı model(class)

    // (29)
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Full Name")] // View ekranında gözükecek olan text bilgi
        [Required(ErrorMessage ="Full Name gerekli bilgidir..")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Full Name 3-50 karakter arasında olmalıdır...")]
        public string? FullName { get; set; }

        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage ="Profile Picture gereklidir..")]
        public string? ProfilePictureURL { get; set; }
        // direkt resim olarak tutmak yerine resmin bulunduğu yer olarak tutmak vt boyutu ve performansını artırmak için iyidir

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography bilgisi gereklidir..")]
        public string? Bio {  get; set; }

        // Relations
        // ? koyarak null da gelse validationdan geçmesini sağlamak

        public List<Actor_Movie>? Actors_Movies { get; set; } // Bir aktor birden fazla Movie de oynayabilir. 

    }
}
