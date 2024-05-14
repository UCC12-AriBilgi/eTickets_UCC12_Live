using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        //private readonly AppDbContext _context; service tarafında olacağı için
        private readonly IActorsService _service;

        //constructor - ctor code snippet
        public ActorsController(IActorsService service)
        {
            //_context = context; // AppDbContext i içeri almış oluyorum.
            _service= service;
        }


        public async Task<IActionResult> Index()
        {
            // Listelemeyi yapacak View...Veriler direkt controller üzerinden değil service üzerinden alınıyor.

            var actorsData= await _service.GetActorsAsync(); // VT deki Actors tablosundaki verileri al..Bir liste yapısı olarak actorsData değişgenine yerleştir.

            return View(actorsData); // olusan değişgen içeriğini View'a postalar
        }

        // (24)
        // Get : Actors/Create
        public IActionResult Create()
        {
            return View(); // Create view a dallan
        }

        // (24)
        // Post : Actors/Create den gelen bilgileri yakalama
        [HttpPost] // Request
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            // (25)
            if (!ModelState.IsValid)
            {
                // Eğer benim Create formumdan gelen verilerde bir uyumsuzluk varsa hiçbir şey yapma.
                // 
                return View(actor);
            }

            _service.AddAsync(actor);

            return RedirectToAction(nameof(Index)); // Index sayfasına tekrardan yönlendirme yapılıyor.

        }

        // (26)
        // Get: Actors/Detail/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails= await _service.GetActorAsync(id); // tekbir actoru getiriyor

            if (actorDetails == null)
            {
                return View("Empty"); // eğer ilgili kayıt gelmemişse gidilecek olan View
            }

            return View(actorDetails);
        }

        // (27)
        // Get: Actors/Edit/1--- Ekrana getiren kısım
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actorRecord = await _service.GetActorAsync(id); // tekbir actoru getiriyor

            if (actorRecord == null)
            {
                return View("Empty"); // eğer ilgili kayıt gelmemişse gidilecek olan View
            }

            return View(actorRecord);
        }
        // (27)
        [HttpPost] // Edit Viewdan gönderilen bilgiyi yakalamak
        public IActionResult Edit(int id, [Bind("Id","FullName","ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            
            _service.UpdateAsync(actor);
        }
    }
}
