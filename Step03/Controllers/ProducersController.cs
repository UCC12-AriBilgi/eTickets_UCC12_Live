using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        //constructor - ctor code snippet
        public ProducersController(AppDbContext context)
        {
            _context = context; // AppDbContext i içeri almış oluyorum.
        }

        public IActionResult Index()
        {
            // Listelemeyi yapacak View

            var producersData = _context.Producers.ToList(); // VT deki Producers tablosundaki verileri al..Bir liste yapısı olarak producersData değişgenine yerleştir.

            return View(producersData); // olusan değişgen içeriğini View'a postalar
        }
    }
}
