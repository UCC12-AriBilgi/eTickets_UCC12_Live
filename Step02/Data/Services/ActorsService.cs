using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        // constructor...Injection
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Actor GetActor(int id) // GetById
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetActors() // GetAll
        {
            // (17.2)
            var records = await _context.Actors.ToListAsync();

            return records;
        }

        public Actor Update(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
