using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace eTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        private readonly AppDbContext _context;

        // constructor...Injection
        public ActorsService(AppDbContext context) : base(context) //injection
        {
            
        }

        //    public async Task AddAsync(Actor actor) // Ekleme
        //    {
        //        await _context.Actors.AddAsync(actor);

        //        await _context.SaveChangesAsync();
        //    }

        //    public void DeleteAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<Actor> GetActorAsync(int id) // Index Listeleme için
        //    {
        //        var actorRecord=await _context.Actors.FirstOrDefaultAsync(ar => ar.Id == id);

        //        return actorRecord;
        //    }

        //    public async Task<IEnumerable<Actor>> GetActorsAsync()
        //    {
        //        var records=await _context.Actors.ToListAsync();

        //        return records;
        //    }

        //    public async Task UpdateAsync(int id, Actor actor)
        //    {
        //        //Actor? actorToUpdate = _context.Actors.Where(a=>a.Id==actor.Id).FirstOrDefault();
        //        //Actor? actorToUpdate = _context.Actors.FirstOrDefault(a=>a.Id==id);
        //        //if (actorToUpdate!=null)
        //        //{
        //        //    _context.Entry(actorToUpdate).CurrentValues.SetValues(actor);
        //        //   await _context.SaveChangesAsync();
        //        //}

        //        _context.Actors.Update(actor);
        //        await _context.SaveChangesAsync();
        //    }
    }
}
