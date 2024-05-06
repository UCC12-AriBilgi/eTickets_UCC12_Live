using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    // VT ile aradaki tercüman olacağı için bunu DbContext(EF içindeki) sınıfından kalıtıyorum.
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

    }
}
