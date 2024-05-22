using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Models;
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

        // 40 
        //Get: Producer/Details/1
        // (21)
        public async Task<IActionResult> Details(int id)
        {
            //var actorDetails = _service.GetById(id);
            // (23)
            var producerDetails = await _service.GetByIdAsync(id);

            if (producerDetails == null) { return View("NotFound"); }

            return View(producerDetails);
        }

        // (19)
        //Get: Producera/Create
        public IActionResult Create()
        {
            return View();
        }

        // (20)
        //Post: Producers/Create (Save kısmı)
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            //_service.Add(actor);
            // (23)
            await _service.AddAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        // Get: Actors/Edit/1
        // (24)
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id); // var mı/yok mu

            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        // Post
        // (25) Update kısmı
        [HttpPost] // View tarafından gönderilecek verileri yakalamak için
        public IActionResult Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            _service.UpdateAsync(id, producer); // Servisde çalışacak kısım

            return RedirectToAction(nameof(Index));

        }

        // Get : Actors/Delete/1
        // (26)
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id); // var mı/yok mu

            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        // Post
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = _service.GetByIdAsync(id);

            if (producerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }



    }
}
