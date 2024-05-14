using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;

namespace eTickets.Data.Interfaces
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Movie GetMovieById(int id);

        Movie AddNewMovie(NewMovieVM movie); //

        Movie UpdateMovie(NewMovieVM movie); //

        //NewMovieDropdownsVM GetNewMovieDropdownsValues();
    }
}
