using eTickets.Data;
using eTickets.Data.Interfaces;
using eTickets.Data.Static;
using eTickets.Models;
using eTickets.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace eTickets.Controllers
{
    //54
    //[Authorize]
    //55
    [Authorize(Roles = UserRoles.Admin)] // sadece Admin hk.sahip olanlar için
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        //constructor - ctor code snippet
        public MoviesController(IMoviesService service)
        {
            //_context = context; // AppDbContext i içeri almış oluyorum.

            // 40.Movie
            _service = service; // Servis yapısını içeri almış oluyorum.
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            // Listelemeyi yapacak View

            //var moviesData = _context.Movies.ToList(); // VT deki Movies tablosundaki verileri al..Bir liste yapısı olarak moviesData değişgenine yerleştir.

            //var moviesData = _service.GetAllAsync();
            var moviesData = await _service.GetAllAsync(n => n.Cinema);
            ;
            return View(moviesData); // olusan değişgen içeriğini View'a postalar
        }

        // 41
        // Get: Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            if (movieDetails == null) { return View("NotFound"); }

            return View(movieDetails);
        }

        // 42
        //Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropDownsData = await _service.GetNewMovieDropdownsValues();

            // Controllerdan Create View tarafına oluşan dropdownlist bilgilerini aktarmam lazım ki görünsünler.

            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");

            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");

            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");

            return View();
        }

        //Post: Movies/Create
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                // Herhangi bir post anında eğer sayfada modelstate valid değilse buraya düşecek. Ama ViewBag in yapısı gereği post gibi işlemlerde içeriği siliniyor. dolayısı ile tekrardan oluşturacağız.

                var movieDropDownsData = await _service.GetNewMovieDropdownsValues();

                // Controllerdan Create View tarafına oluşan dropdownlist bilgilerini aktarmam lazım ki görünsünler.

                ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");

                ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");

                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));

        }

        // 42
        // Get: Moviess/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id); // var mı/yok mu

            if (movieDetails == null) return View("NotFound");

            var data = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.movieCategory,//
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(acmo => acmo.ActorId).ToList()
            };

            // DropdownList
            var movieDropDownsData = await _service.GetNewMovieDropdownsValues();

            // Controllerdan Create View tarafına oluşan dropdownlist bilgilerini aktarmam lazım ki görünsünler.

            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");

            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");

            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");

            return View(data);
        }

        // Post
        [HttpPost] // View tarafından gönderilecek verileri yakalamak için
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropDownsData = await _service.GetNewMovieDropdownsValues();

                // Controllerdan Create View tarafına oluşan dropdownlist bilgilerini aktarmam lazım ki görünsünler.

                ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");

                ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");

                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.UpdateMovieAsync(movie); // Servisde çalışacak kısım

            return RedirectToAction(nameof(Index));

        }

        // 44
        public async Task<IActionResult> Filter(string searchString)
        {
            // Burası film adı veya Description üzerinde arama kısmı

            // Öncelikle VT Movies tablosundaki tüm kayıtları bir okuyalım
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            // Searchtext i doldurulmadan da arama butonuna basılmış olabilir. searchString in dolu olup olmadığına bakılıyor

            if (!string.IsNullOrEmpty(searchString)) 
            {
                // Boş değilse

                var filteredResult = allMovies
                                .Where(n => n.Name.ToLower()
                                .Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                return View("Index",filteredResult);


            }

            return View("Index", allMovies);

        }

    }
}
