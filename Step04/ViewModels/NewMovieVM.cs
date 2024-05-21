using eTickets.Data.Enums;
using eTickets.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eTickets.ViewModels
{
    public class NewMovieVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Movie Name")]
        [Required(ErrorMessage = "Film adı gerekli bilgidir...")]
        public string? Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Film açıklaması gerekli bilgidir...")]
        public string? Description { get; set; }

        [Display(Name = "Price (TL)")]
        [Required(ErrorMessage = "Fiyat bilgisi gerekli bilgidir...")]
        public double Price { get; set; } // Bilet fiyatı

        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Poster URL gerekli bilgidir...")]
        public string? ImageURL { get; set; } // Filmin afişi

        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Film başlangıç tarihi gerekli bilgidir...")]
        public DateTime StartDate { get; set; } // Vizyona giriş tarihi

        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "Film bitiş tarihi gerekli bilgidir...")]
        public DateTime EndDate { get; set; } // Vizyondan kalkış tarihi

        // Film türü için

        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Film kategorisi gerekli bilgidir...")]
        public MovieCategory movieCategory { get; set; }

        // Relations (One-to-Many)
        // Burası çoktan seçmeli dropdownlist olarak gelecek
        [Display(Name = "Select Actor(s)")]
        [Required(ErrorMessage = "Film aktorleri gerekli bilgidir...")]
        public List<int> ActorIds { get; set; } // Dropdown için

        // Burası çoktan seçmeli dropdownlist olarak gelecek
        [Display(Name = "Select Cinema")]
        [Required(ErrorMessage = "Cinema bilgisi gerekli bilgidir...")]
        public int CinemaId {  get; set; }

        // Burası çoktan seçmeli dropdownlist olarak gelecek
        [Display(Name = "Select Producer")]
        [Required(ErrorMessage = "Film yönetmeni gerekli bilgidir...")]
        public int ProducerId { get; set; }

    }
}
