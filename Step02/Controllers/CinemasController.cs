using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{

    public class CinemasController : Controller
    {
        // (16)
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cinemasData = await _context.Cinemas.ToListAsync();

            return View(cinemasData);
        }
    }
}
