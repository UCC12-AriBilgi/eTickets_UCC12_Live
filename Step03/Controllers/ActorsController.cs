using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{

    public class ActorsController : Controller
    {
        // (16)
        //private readonly AppDbContext _context;
        // (18.3)
        private readonly IActorsService _service;

        // (16)
        //public ActorsController(AppDbContext context)
        //{
        //    _context = context;    
        //}

        // (18.3)
        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        // (16)
        //public IActionResult Index()
        //{
        //  var actorsData= _context.Actors.ToList();
        //
        //  return View(actorsData);
        //}

        // (18.3)
        //public IActionResult Index()
        //{
        //    var actorsData = _service.GetAll();

        //    return View(actorsData);
        //}



        // (18.5)
        public async Task<IActionResult> Index()
        {
            //var actorsData = await _service.GetAll();
            // (23)
            var actorsData = await _service.GetAllAsync();

            return View(actorsData);
        }

        // (19)
        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // (20)
        //Post: Actors/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            //_service.Add(actor);
            // (23)
            await _service.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        // (21)
        public async Task<IActionResult> Details(int id)
        {
            //var actorDetails = _service.GetById(id);
            // (23)
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) { return View("NotFound"); }

            return View(actorDetails);
        }
    }
}
