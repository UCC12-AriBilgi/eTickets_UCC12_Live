using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        // constructor...Injection
        public ActorsService(AppDbContext context) : base(context)
        {
        }
    }
}
