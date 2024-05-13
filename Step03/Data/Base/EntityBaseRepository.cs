using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        // constructor
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;     
        }



        public void Add(T entity)
        {
            _context.Set<T>().Add(entity); // gelen modele göre ayarlama
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity=_context.Set<T>().FirstOrDefault(n=> n.Id == id);

            EntityEntry entityEntry = _context.Entry<T>(entity);

            entityEntry.State=EntityState.Deleted; // silinecektir diye işaretledi.

            _context.SaveChanges(); // sildi

        }

        //public IEnumerable<T> GetAll()
        //{
        //    _context.Set<T>().ToList();
        //}

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();


        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties) // Parametreli yapı
        {
            IQueryable<T> query = _context.Set<T>();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public T GetById(int id) => _context.Set<T>().FirstOrDefault(n => n.Id == id);


        public void Update(int id, T entity)
        {
           EntityEntry entityEntry=_context.Entry<T>(entity);

            entityEntry.State=EntityState.Modified; // Güncelledim

            _context.SaveChanges(); // Yazdım
        }
    }


}
