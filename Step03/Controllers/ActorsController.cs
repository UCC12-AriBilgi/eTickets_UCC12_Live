using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        //constructor - ctor code snippet
        public ActorsController(AppDbContext context)
        {
            _context = context; // AppDbContext i içeri almış oluyorum.
        }


        public IActionResult Index()
        {
            // Listelemeyi yapacak View

            var actorsData=_context.Actors.ToList(); // VT deki Actors tablosundaki verileri al..Bir liste yapısı olarak actorsData değişgenine yerleştir.

            return View(actorsData); // olusan değişgen içeriğini View'a postalar
        }
    }
}
