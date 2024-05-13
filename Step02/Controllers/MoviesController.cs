using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        // Notes.16
        private readonly AppDbContext _context;

        //constructor - ctor code snippet
        public MoviesController(AppDbContext context)
        {
            _context = context; // AppDbContext i içeri almış oluyorum.
        }

        public IActionResult Index()
        {
            // Listelemeyi yapacak View

            var moviesData = _context.Movies.ToList(); // VT deki Movies tablosundaki verileri al..Bir liste yapısı olarak moviesData değişgenine yerleştir.

            return View(moviesData); // olusan değişgen içeriğini View'a postalar
        }
    }
}
