using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema logo gereklidir.")]
        public string? Logo { get; set; }

        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Cinema adı gereklidir.")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema açıklama gereklidir.")]
        public string? Description { get; set; }

        //Relations
        public List<Movie>? Movies { get; set; } // Bir cinemada birçok film olabilir
    }
}
