
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTickets.Data.Base
{
    // Ortak CRUD metotlarını biraraya toplayacağımız class/service gibi çalışcak
    // Yani VT tarafıyla konuşacak kısım

    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class,IEntityBase, new()
    {
        private readonly AppDbContext _context;

        // constructor
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        // (38)
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);

            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity=await _context.Set<T>().FirstOrDefaultAsync(e=> e.Id==id);

            EntityEntry entityEntry = _context.Entry<T>(entity);

            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }




    }
}
