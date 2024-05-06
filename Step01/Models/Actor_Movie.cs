namespace eTickets.Models
{
    //Burası ara bir bağlaşım tablo yapısı
    // Many-to-many türü ilişkilendirme yapılması gerektiğinde

    public class Actor_Movie
    {
        public int MovieID { get; set; }
        public Movie Movie { get; set; } // Movie modelinden gelecek bilgi için


        public int ActorID { get; set; }
        public Actor Actor { get; set; } // Actor modelinden gelecek bilgi için

    }
}
