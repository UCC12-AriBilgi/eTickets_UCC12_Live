using eTickets.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    // Varolan Movie model yapısı yerine kendime göre düzenleyeceğim VM yaratıyorum.
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Film Adı")]
        [Required(ErrorMessage = "Film adı girilmesi zorunludur..")]
        public string? Name { get; set; }

        [Display(Name="Film açıklaması")]
        [Required(ErrorMessage = "Film açıklaması gereklidir..")]
        public string? Description { get; set; }

        [Display(Name = "Bilet fiyatı")]
        [Required(ErrorMessage = "Bilet fiyatı gereklidir..")]
        public double Price { get; set; }

        [Display(Name = "Film afişi")]
        [Required(ErrorMessage = "Film afişi gereklidir..")]
        public string? ImageURL { get; set; }

        [Display(Name = "Vizyona giriş tarihi")]
        [Required(ErrorMessage = "Vizyona giriş tarihi gereklidir..")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Vizyondan kalkış tarihi")]
        [Required(ErrorMessage = "Vizyondan kalkış tarihi gereklidir..")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Film kategorisi")]
        [Required(ErrorMessage = "Film kategorisi gereklidir..")]
        public MovieCategory MovieCategory { get; set; }

        // Relations
        [Display(Name = "Aktör seç")]
        [Required(ErrorMessage = "Aktör bilgisi gereklidir..")]
        public List<int>? ActorIds { get; set; }

        [Display(Name = "Sinema seç")]
        [Required(ErrorMessage = "Sinema bilgisi gereklidir..")]
        public int CinemaId { get; set; }

        [Display(Name = "Yönetmen seç")]
        [Required(ErrorMessage = "Yönetmen bilgisi gereklidir..")]
        public int ProducerId { get; set; }
    }
}
