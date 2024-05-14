using eTickets.Data;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{

    public class ActorsController : Controller // Controller sınıfından inherit
    {
        // (16)
        private readonly AppDbContext _context;


        // (16)
        // inject constructor
        public ActorsController(AppDbContext context)
        {
            _context = context;
        }
        // (22)
        //public ActorsController(IActorsService service)
        //{
        //    _service = service;
        //}

        // (16)
        public IActionResult Index()
        {
            var actorData = _context.Actors.ToList();

            return View(actorData);
        }
        // 22
        //public IActionResult Index()
        // 22.5
        //public async Task<IActionResult> Index()
        //{
        //    //16.
        //    //var actorsData= _context.Actors.ToList();
        //    //22
        //    //var actorsData= _service.GetActors();
        //    // 22.5
        //    var actorsData= await _service.GetActors();

        //    return View(actorsData);
        //}

        //Get: Actors/Create
        // (23)
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        //{
        //    // (24)
        //    if (!ModelState.IsValid)
        //    {
        //        return View(actor);
        //    }

        //    _service.Add(actor);

        //    return RedirectToAction(nameof(Index));
        //}


    }
}
