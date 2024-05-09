using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Interfaces
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Movie GetMovieById(int id);

        Movie AddNewMovie(Movie movie); //

        Movie UpdateMovie(Movie movie); //

        //NewMovieDropdownsVM GetNewMovieDropdownsValues();
    }
}
