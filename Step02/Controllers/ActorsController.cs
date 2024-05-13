using eTickets.Data;
using eTickets.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        // (16)
        //private readonly AppDbContext _context;
        // (17.3)
        private readonly IActorsService _service;

        //constructor - ctor code snippet
        // (16)
        //public ActorsController(AppDbContext context)
        //{
        //    _context = context; // AppDbContext i içeri almış oluyorum.
        //}

        // (17.3)
        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        // (17.5)
        public async Task<IActionResult> Index()
        {
            // Listelemeyi yapacak View

            var actorsData= await _service.GetActors(); // VT deki Actors tablosundaki verileri al..Bir liste yapısı olarak actorsData değişgenine yerleştir.

            return View(actorsData); // olusan değişgen içeriğini View'a postalar
        }
    }
}
