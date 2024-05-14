using eTickets.Models;

namespace eTickets.Data.Interfaces
{
    public interface IActorsService
    {
        // (18)
        //IEnumerable<Actor> GetAll();

        // (18.4)
        //Task<IEnumerable<Actor>> GetAll();
        // (23)
        Task<IEnumerable<Actor>> GetAllAsync();

        //Actor GetById(int id);
        // (23)
        Task<Actor> GetByIdAsync(int id);

        //void Add(Actor actor);
        // (23)
        Task AddAsync(Actor actor);

        Actor Update(int id, Actor actor);

        void Delete(int id);

    }
}
