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

            // 40.Movie
            _service = service; // Servis yapısını içeri almış oluyorum.
        }

        public async Task<IActionResult> Index()
        {
            // Listelemeyi yapacak View

            //var moviesData = _context.Movies.ToList(); // VT deki Movies tablosundaki verileri al..Bir liste yapısı olarak moviesData değişgenine yerleştir.

            //var moviesData = _service.GetAllAsync();
            var moviesData = await _service.GetAllAsync(n => n.Cinema);
 ;
            return View(moviesData); // olusan değişgen içeriğini View'a postalar
        }

        //Get: Movies/Details/1

    }
}
