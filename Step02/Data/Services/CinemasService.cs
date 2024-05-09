using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
        }
    }
}
