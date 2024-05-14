﻿using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {

        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        //(18.2)
        //public IEnumerable<Actor> GetAll()
        //{
        //    var result= _context.Actors.ToList();

        //    return result;
        //}

        //(18.4)
        //public async Task<IEnumerable<Actor>> GetAll()
        //{
        //    var result = _context.Actors.ToList();

        //    return result;
        //}

        // (22)
        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();

            return result;
        }

        //(22)
        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);

            return result;
        }

        //(20) (22)
        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);

            await _context.SaveChangesAsync();
        }

        public Actor Update(int id, Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
