using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    // Actor bilgilerinin tutulacağı model(class)

    public class Actor
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string ProfilePictureURL { get; set; }
        // direkt resim olarak tutmak yerine resmin bulunduğu yer olarak tutmak vt boyutu ve performansını artırmak için iyidir

        public string Bio {  get; set; }

        // Relations
        public List<Actor_Movie> Actors_Movies { get; set; } // Bir aktor birden fazla Movie de oynayabilir. 

    }
}
