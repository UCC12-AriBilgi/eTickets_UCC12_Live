using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using eTickets.ViewModels;

namespace eTickets.Data
{
    // VT ile aradaki tercüman olacağı için bunu DbContext(EF içindeki) sınıfından kalıtıyorum.
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Step01.8 - İlşkilerin belirtilmesi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // override tanımı normal temel sınıftaki metodun yerine onu ezerek kendi metodumun geçerli olması için.

            // İlişkiler
            modelBuilder.Entity<Actor_Movie>().HasKey(acmo => new {
                acmo.ActorId,
                acmo.MovieId
            });

            // Actor_Movie <-->> Actor
            modelBuilder.Entity<Actor_Movie>()
                .HasOne(m => m.Actor) // Actor tablosunda 1 tane kayıt
                .WithMany(acmo => acmo.Actors_Movies) // ActorMovie de çok olabilir
                .HasForeignKey(m => m.ActorId); // ActorId alanı üzerinden haberleşecek

            // Actor_Movie <-->> Movie
            modelBuilder.Entity<Actor_Movie>()
                .HasOne(m => m.Movie) // Actor tablosunda 1 tane kayıt
                .WithMany(acmo => acmo.Actors_Movies) // ActorMovie de çok olabilir
                .HasForeignKey(m => m.MovieId); // MovieId alanı üzerinden haberleşecek

            // tanımlar yapıldıktan sonra yarat..ModelBuilder uzerinde yaptıklarımı uygula
            base.OnModelCreating(modelBuilder);

        }

        // VT tarafında oluşacak olan modele karşılık gelecek tablolarım

        public DbSet<Actor> Actors { get; set; } // class:Actor --> vt:Actors
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
    // VT ile aradaki tercüman olacağı için bunu DbContext(EF içindeki) sınıfından kalıtıyorum.
public DbSet<eTickets.ViewModels.NewMovieVM> NewMovieVM { get; set; } = default!;


    }
}
