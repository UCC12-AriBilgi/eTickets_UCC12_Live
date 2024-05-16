
namespace eTickets.Data.Base
{
    // Ortak CRUD metotlarını biraraya toplayacağımız class/service gibi çalışcak

    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class,IEntityBase, new()
    {
        private readonly AppDbContext _context;

        // constructor
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }





        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
