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

            var actorsData= _service.GetAll(); // VT deki Actors tablosundaki verileri al..Bir liste yapısı olarak actorsData değişgenine yerleştir.

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
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            // (25)
            if (!ModelState.IsValid)
            {
                // Eğer benim Create formumdan gelen verilerde bir uyumsuzluk varsa hiçbir şey yapma.
                // 
                return View(actor);
            }

            _service.Add(actor);

            return RedirectToAction(nameof(Index)); // Index sayfasına tekrardan yönlendirme yapılıyor.

        }

        // (28)
        // Get: Actors/Detail/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails= _service.GetById(id); // tekbir actoru getiriyor

            if (actorDetails == null)
            {
                return View("Empty"); // eğer ilgili kayıt gelmemişse gidilecek olan View
            }

            return View(actorDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actorRecord =  _service.GetById(id);

            if (actorRecord == null)
            {
                return View("Empty");
            }
            return View(actorRecord);

            //if(actor == null)
            //{
            //    return View("Empty");
            //}
            //return View(actor); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "FullName", "ProfilePictureURL", "Bio")] Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
             _service.Update(id,actor);

            return RedirectToAction("Details",actor);

            //--------------
            //return View("Details",actor);
            //return RedirectToAction(nameof(Details),actor);
        }
    }
}
