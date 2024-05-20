using eTickets.Data;
using eTickets.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        //constructor - ctor code snippet
        public MoviesController(IMoviesService service)
        {
            //_context = context; // AppDbContext i içeri almış oluyorum.

            _service = service; // Servis yapısını içeri almış oluyorum.
        }

        public IActionResult Index()
        {
            // Listelemeyi yapacak View

            //var moviesData = _context.Movies.ToList(); // VT deki Movies tablosundaki verileri al..Bir liste yapısı olarak moviesData değişgenine yerleştir.

            var moviesData = _service.GetAll();

            return View(moviesData); // olusan değişgen içeriğini View'a postalar
        }

        //Get: Moviess/Details/1
        // (40) 
        public IActionResult Details(int id)
        {
            var movieDetails = _service.GetMovieById(id);

            if (movieDetails == null) { return View("NotFound"); }

            return View(movieDetails);
        }
    }
}
