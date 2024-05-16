using eTickets.Models;

namespace eTickets.Data.Base
{
    // Burada ortak olacak tüm metotlar Generic yapısın bulunacaklar.

    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new() 
    {
        // (33)


        Task<IEnumerable<T>> GetAllAsync(); // Tüm kayıtları getirme

        Task<T> GetByIdAsync(int id); // tek bir kayıt getirme

        Task AddAsync(T entity); // Kayıt ekleme

        Task UpdateAsync(int id, T entity); // Kayıt güncelleme

        Task DeleteAsync(int id); // Kayıt Silme
    }
}
