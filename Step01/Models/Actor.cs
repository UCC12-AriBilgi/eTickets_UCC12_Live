namespace eTickets.Models
{
    // Actor bilgilerinin tutulacağı model(class)

    public class Actor
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string ProfilePictureURL { get; set; }
        // direkt resim olarak tutmak yerine resmin bulunduğu yer olarak tutmak vt boyutu ve performansını artırmak için iyidir

        public string Bio {  get; set; }

    }
}
