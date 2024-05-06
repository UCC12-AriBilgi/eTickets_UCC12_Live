namespace eTickets.Models
{
    // Cinema bilgilerini tutacak class

    public class Cinema
    {
        public int Id { get; set; }

        public string Logo { get; set; }

        public string Name { get; set; } // Cinema adı

        public string Description { get; set; } 

        // Relations

        public List<Movie> Movies { get; set; } // Şu an Movie tablosuna bağlantı kuruldu. Bir cinemada birçok film oynayabilir
    }
}
