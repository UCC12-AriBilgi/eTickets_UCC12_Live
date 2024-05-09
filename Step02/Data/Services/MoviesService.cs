using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context)
        {
        }

        public Movie AddNewMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Movie UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
