using eTickets.Data.Base;
using eTickets.Models;
using eTickets.ViewModels;

namespace eTickets.Data.Interfaces
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Movie GetMovieById(int id);

        Movie AddNewMovieAsync(NewMovieVM data);

        Movie UpdateMovieAsync(NewMovieVM data);

        NewMovieDropdownsVM GetNewMovieDropdownsValues();

    }
}
