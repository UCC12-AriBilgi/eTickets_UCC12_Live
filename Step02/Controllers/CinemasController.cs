using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        //constructor - ctor code snippet
        public CinemasController(AppDbContext context)
        {
            _context = context; // AppDbContext i içeri almış oluyorum.
        }

        public IActionResult Index()
        {
            // Listelemeyi yapacak View

            var cinemasData = _context.Cinemas.ToList(); // VT deki Cinemas tablosundaki verileri al..Bir liste yapısı olarak actorsData değişgenine yerleştir.

            return View(cinemasData); // olusan değişgen içeriğini View'a postalar
        }
    }
}
