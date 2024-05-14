using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        // (16)
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // (16)
            //var moviesData = await _context.Movies.ToListAsync();
            // (17.5)
            var moviesData = await _context.Movies.Include(c => c.Cinema).ToListAsync();

            // (16)
            //return View();
            // (17.3)
            return View(moviesData);
        }
    }
}
