using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, IEntityBaseRepository<Cinema>
    {
        public CinemasService(AppDbContext context) : base(context)
        {
        }
    }
}
