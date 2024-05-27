using System.ComponentModel.DataAnnotations;

namespace eTickets.ViewModels
{
    public class RegisterVM
    {
        [Display(Name ="Full Name")]
        [Required(ErrorMessage ="Tam ad gerekli bilgidir...")]
        public string FullName { get; set; }

        [Display(Name = "EMail Address")]
        [Required(ErrorMessage = "EMail gerekli bilgidir...")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage ="Confirm Password gerekli bilgidir...")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor..Kontrol ediniz...")]
        public string ConfirmPassword { get; set; }
    }
}
