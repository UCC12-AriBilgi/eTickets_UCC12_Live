using eTickets.Data;
using eTickets.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        //private readonly AppDbContext _context;
        private readonly IProducersService _service;
        //constructor - ctor code snippet
        public ProducersController(IProducersService service)
        {
            _service = service; // Servisi içeri almış oluyorum.
        }

        public async Task<IActionResult> Index()
        {
            // Listelemeyi yapacak View

            var producersData = await _service.GetAllAsync(); // VT deki Producers tablosundaki verileri al..Bir liste yapısı olarak producersData değişgenine yerleştir.

            return View(producersData); // olusan değişgen içeriğini View'a postalar
        }
    }
}
