using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Interfaces
{
    public interface IActorsService
    {
        // 17.4
        Task<IEnumerable<Actor>> GetActors(); // GetAll 

        Actor GetActor(int id); // GetById

        void Add(Actor actor);

        Actor Update(int id, Actor actor);

        void Delete(int id);
    }
}
