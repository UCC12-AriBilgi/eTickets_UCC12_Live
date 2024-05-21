using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Models;
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

        // 41
        // Get: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetByIdAsync(id);

            if (movieDetails == null) { return View("NotFound"); }

            return View(movieDetails);
        }

        // 42
        //Get: Movies/Create
        public IActionResult Create()
        {
            var movieDropDownsData = _service.GetNewMovieDropdownsValues();





            return View();
        }

        //Post: Movies/Create
        [HttpPost]
        //public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Movie movie)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(movie);
        //    }

        //    //_service.Add(actor);
        //    // (23)
        //    await _service.AddAsync(movie);

        //}
    }
}
