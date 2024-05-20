using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        //private readonly AppDbContext _context;
        private readonly ICinemasService _service;

        //constructor - ctor code snippet
        public CinemasController(ICinemasService service)
        {
            //_context = context; // AppDbContext i içeri almış oluyorum.
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            // Listelemeyi yapacak View

            var cinemasData = await _service.GetAllAsync();

            return View(cinemasData);
        }

        // (19)
        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        // (20)
        //Post: Actors/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            //_service.Add(actor);
            // (23)
            await _service.AddAsync(cinema);

            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        // (21)
        public async Task<IActionResult> Details(int id)
        {
            //var actorDetails = _service.GetById(id);
            // (23)
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null) { return View("NotFound"); }

            return View(cinemaDetails);
        }

        // Get: Actors/Edit/1
        // (24)
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id); // var mı/yok mu

            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }


        // Post
        // (25) Update kısmı
        [HttpPost] // View tarafından gönderilecek verileri yakalamak için
        public IActionResult Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            _service.UpdateAsync(id, cinema); // Servisde çalışacak kısım

            return RedirectToAction(nameof(Index));

        }

        // Get : Actors/Delete/1
        // (26)
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id); // var mı/yok mu

            if (cinemaDetails == null) return View("NotFound");

            return View(cinemaDetails);
        }

        // Post
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = _service.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
