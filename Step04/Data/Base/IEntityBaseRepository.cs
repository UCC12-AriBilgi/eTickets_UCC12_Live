using eTickets.Models;
using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    // Burada ortak olacak tüm metotlar Generic yapısında bulunacaklar.

    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        // (33)


        Task<IEnumerable<T>> GetAllAsync(Func<object, object> value); // Tüm kayıtları getirme

        // 40.Movie
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(int id); // tek bir kayıt getirme

        Task AddAsync(T entity); // Kayıt ekleme

        Task UpdateAsync(int id, T entity); // Kayıt güncelleme

        Task DeleteAsync(int id); // Kayıt Silme
    }
}
