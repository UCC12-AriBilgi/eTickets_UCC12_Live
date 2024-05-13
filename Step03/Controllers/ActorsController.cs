﻿using eTickets.Data;
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
            // Listelemeyi yapacak View

            var actorsData= _service.GetAll(); // VT deki Actors tablosundaki verileri al..Bir liste yapısı olarak actorsData değişgenine yerleştir.

            return View(actorsData); // olusan değişgen içeriğini View'a postalar
        }

        // (28)
        // Get : Actors/Create
        public IActionResult Create()
        {
            return View(); // Create view a dallan
        }

        // (28)
        // Post : Actors/Create den gelen bilgileri yakalama
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                // Eğer benim Create formumdan gelen verilerde bir uyumsuzluk varsa hiçbir şey yapma.
                // 
                return View(actor);
            }

            _service.Add(actor); 

            return RedirectToAction(nameof(Index));

        }
    }
}
