using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class CinemasSevice : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasSevice(AppDbContext context) : base(context)
        {
                
        }
    }
}
