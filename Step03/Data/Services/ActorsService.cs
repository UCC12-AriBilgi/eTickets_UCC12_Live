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

        public async Task AddAsync(Actor actor) // Ekleme
        {
            await _context.Actors.AddAsync(actor);

            await _context.SaveChangesAsync();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> GetActorAsync(int id) // Index Listeleme için
        {
            var actorRecord=await _context.Actors.FirstOrDefaultAsync(ar => ar.Id == id);

            return actorRecord;
        }

        public async Task<IEnumerable<Actor>> GetActorsAsync()
        {
            var records=await _context.Actors.ToListAsync();

            return records;
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
