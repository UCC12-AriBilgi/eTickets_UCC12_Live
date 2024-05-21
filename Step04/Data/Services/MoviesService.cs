using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Models;
using eTickets.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;


        // constructor
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }


        // 40.Movie 
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(acmo => acmo.Actors_Movies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefault(n => n.Id == id);

            return movieDetails;
        }
        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            // Önce Movie data oluşturuluyor.
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId,
                movieCategory = data.MovieCategory
            };

            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            // Sonra da bu filimde oynayan actorler için
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };

                await _context.Actors_Movies.AddAsync(newActorMovie);
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = _context.Movies.FirstOrDefault(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                // update kısmı
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.movieCategory = data.MovieCategory;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.ProducerId = data.ProducerId;

                await _context.SaveChangesAsync();
            }

            // Öncelikle bu movie ile ilgili olan Actorleri ara tablodan(Actors_Movies) kaldıralım...

            // Burada Actors_Movie tablosundaki data dan gelen Id(MovieId) e sahip olan kayıtlar seçiliyor.

            var existingActors = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();

            // Bulduğun ilgili aktörleri ilgili movieden kaldır.
            _context.Actors_Movies.RemoveRange(existingActors);

            await _context.SaveChangesAsync();


            // Yeni seçilen Actorleri Actors_Movies tablosuna ekleyelim.

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };

                await _context.Actors_Movies.AddAsync(newActorMovie);
            }

            await _context.SaveChangesAsync();

        }
        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            // Create ekranında bulunacak dropdownlar için listeler oluşturacak...

            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors
                     .OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()

            };

            return response;
        }

    }
}
