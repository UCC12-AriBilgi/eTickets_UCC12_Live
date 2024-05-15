using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        // Bu servis yapısı içersine VT ile uğraşma kısımlarını aldım.
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        //(18.2)
        // VT tarafından Actors tablosundaki tüm kayıtları getirecek
        //public IEnumerable<Actor> GetAll()
        //{
        //    var result = _context.Actors.ToList();

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

        public async Task UpdateAsync(int id, Actor actor)
        {
            _context.Update(actor);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id,Actor actor)
        {
            _context.Remove(actor);

            _context.SaveChanges();
        }

    }
}
