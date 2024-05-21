using eTickets.Data.Base;
using eTickets.Models;
using eTickets.ViewModels;

namespace eTickets.Data.Interfaces
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {

        //List<Movie> GetAll();

        // Movie GetMovieById(int id);

        // Task AddNewMovieAsync(NewMovieVM data);

        // Task UpdateMovieAsync(NewMovieVM data);

        // NewMovieDropdownsVM GetNewMovieDropdownsValues();




    }
}
