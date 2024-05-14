using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? ProfilePictureURL { get; set; }
        // direkt resim olarak tutmak yerine resmin bulunduğu yer olarak tutmak vt boyutu ve performansını artırmak için iyidir

        public string? Bio { get; set; }

        // Relations
        public List<Movie>? Movies { get; set; } // Movie modelini besliyor..
    }
}
