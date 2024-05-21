using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Models;
using eTickets.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        //private readonly AppDbContext _context;


        // constructor
        public MoviesService(AppDbContext context) : base(context)
        {
            //_context = context;
        }

        // 40.Movie 
    //    public Movie AddNewMovie(NewMovieVM data)
    //    {
    //        // Önce Movie data oluşturuluyor.
    //        var newMovie = new Movie()
    //        {
    //            Name = data.Name,
    //            Description = data.Description,
    //            Price = data.Price,
    //            ImageURL = data.ImageURL,
    //            StartDate = data.StartDate,
    //            EndDate = data.EndDate,
    //            CinemaId = data.CinemaId,
    //            ProducerId = data.ProducerId,
    //            movieCategory = data.movieCategory
    //        };

    //        _context.Movies.Add(newMovie);
    //        _context.SaveChanges();

    //        // Sonra da bu filimde oynayan actorler için
    //        foreach (var actorId in data.ActorIds)
    //        {
    //            var newActorMovie = new Actor_Movie()
    //            {
    //                MovieId = newMovie.Id,
    //                ActorId = actorId
    //            };

    //            _context.Actors_Movies.Add(newActorMovie);
    //        }

    //        _context.SaveChanges();

    //        return newMovie;

    //    }

    //    public List<Movie> GetAll()
    //    {
    //        var movieDetails = _context.Movies
    //.Include(c => c.Cinema)
    //.Include(p => p.Producer)
    //.Include(acmo => acmo.Actors_Movies)
    //.ThenInclude(a => a.Actor)
    //.ToList();

    //        return movieDetails;

    //    }


    //    public Movie GetMovieById(int id)
    //    {
    //        var movieDetails= _context.Movies
    //            .Include(c => c.Cinema)
    //            .Include(p => p.Producer)
    //            .Include(acmo => acmo.Actors_Movies)
    //            .ThenInclude(a => a.Actor)
    //            .FirstOrDefault(n => n.Id == id);

    //        return movieDetails;
    //    }

    //    public NewMovieDropdownsVM GetMovieDropdownsValues()
    //    {
    //        var response = new NewMovieDropdownsVM()
    //        {
    //            Actors = _context.Actors
    //                            .OrderBy(n => n.FullName).ToList(),
    //            Cinemas = _context.Cinemas.OrderBy(n => n.Name).ToList(),
    //            Producers = _context.Producers.OrderBy(n => n.FullName).ToList()

    //        };

    //        return response;


    //    }




    //    //============================


    //    //public Task AddAsync(Movie entity)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    public Task AddNewMovieAsync(NewMovieVM data)
    //    {
    //        throw new NotImplementedException();
    //    }



    //    public NewMovieDropdownsVM GetNewMovieDropdownsValues()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task UpdateAsync(int id, Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task UpdateMovieAsync(NewMovieVM data)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<IEnumerable<Movie>> IEntityBaseRepository<Movie>.GetAllAsync()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<Movie> IEntityBaseRepository<Movie>.GetByIdAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }
    }
}
