using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    // Bu interface de tüm modeller için kullanılacak temel CRUD metotlar tanımlarını toplayacağımız kısım

    public interface IEntityBaseRepository<T> where T : class, IEntityBase,new()
    {
        IEnumerable<T> GetAll(); // Tüm kayıtları getirme

        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties); // parametreye bağlı olarak tüm kayıtları getirme

        T GetById(int id); // tek bir kayıt getirmek için

        void Add(T entity); // ilgili model üzerinden kayıt ekleme

        void Update(int id,T entity); // ilgili model üzerinden kayıt güncelleme

        void Delete(int id); // ilgili model üzerinden kayıt silme
    }
}
