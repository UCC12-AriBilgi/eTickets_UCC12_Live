using eTickets.Data.Base;
using eTickets.Data.Interfaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eTickets.Data.Services
{
    // (37)
    public class ActorsService : EntityBaseRepository<Actor>,IActorsService
    {

        public ActorsService(AppDbContext context) : base (context)
        {
           
        }
    }
}
