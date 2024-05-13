using eTickets.Data.Interfaces;
using eTickets.Models;
using System.Linq.Expressions;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        // constructor...Injection
        public ActorsService(AppDbContext context)
        {
        }

        public void Add(Actor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetAll(params Expression<Func<Actor, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Actor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Actor entity)
        {
            throw new NotImplementedException();
        }
    }
}
