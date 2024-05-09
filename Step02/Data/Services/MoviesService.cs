using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context)
        {
            _context= context;
        }

        // 26.adım
        //public Movie AddNewMovie(Movie movie)
        //{
        //    // Standard model yapısı kullanımı
        //}

        public Movie AddNewMovie(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name=data.Name,
                Description=data.Description,
                Price =data.Price,
                ImageURL=data.ImageURL,
                StartDate=data.StartDate,
                EndDate=data.EndDate,
                movieCategory=data.MovieCategory,
                CinemaId = data.CinemaId,
                ProducerId =data.ProducerId
            };

            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            //Bu film için seçilen aktörlerin ActorsMovies ara tablosuna yazılması
            foreach (var ActorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = ActorId
                };
                _context.Actors_Movies.Add(newActorMovie);
            }

            _context.SaveChanges();

            return newMovie;

        }

        public Movie GetMovieById(int id)
        {
            //LINQ sorgusu (InnerJoin)
            var movieDetails= _context.Movies
                                .Include(c=> c.Cinema)
                                .Include(p=> p.Producer)
                                .Include(acmo=> acmo.Actors_Movies)
                                .ThenInclude(a=> a.Actor)
                                .FirstOrDefault(m=> m.Id == id);

            return movieDetails;

        }

        public Movie UpdateMovie(NewMovieVM data)
        {
            var dbMovie = _context.Movies.FirstOrDefault(m => m.Id == data.Id);

            if (dbMovie != null) // ilgili movie var mı / yok mu
            {
                // varsa
                dbMovie.Name= data.Name;
                dbMovie.Description= data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.movieCategory = data.MovieCategory;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.ProducerId = data.ProducerId;

                _context.SaveChanges();
            }

            // Yeni gelen veride actor bilgileri de ilgili movie için değiştirmiş olabilir. Bu yüzden onlarında ActorsMovies tablosunda değiştirilmesi lazım.
            // Önce ilgili movienin actorlerini silmek ardından yeni kayıtları eklemek

            // Varolan ilgili kayıtları silelim
            var existingActors = _context.Actors_Movies.Where(m=> m.MovieId == data.Id).ToList();

            _context.Actors_Movies.RemoveRange(existingActors);

            _context.SaveChanges();

            // Yeni aktör kayıtlarını ekleyelim

            foreach (var ActorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = ActorId
                };
                // dolastıkca yeni kayıt atacak
                _context.Actors_Movies.Add(newActorMovie);
            }

            _context.SaveChanges();

            return dbMovie;
          

        }

        // Dropdowns
        public NewMovieDropdownsVM GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors=_context.Actors.OrderBy(a=> a.FullName).ToList(),
                Cinemas=_context.Cinemas.OrderBy(c=> c.Name).ToList(),
                Producers=_context.Producers.OrderBy(p=> p.FullName).ToList()
            };

            return response;
        }

        // ??
        public Movie AddNewMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
