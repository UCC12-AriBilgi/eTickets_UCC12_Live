using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Interfaces
{
    public interface IActorsService: IEntityBaseRepository<Actor>
    {
        // Interface : Şözleşme

        //Task<IEnumerable<Actor>> GetActorsAsync(); // Burası tüm Actor listesini getirecek

        //Task<Actor> GetActorAsync(int id); // Kayıdı update etmek için kullanılacak

        //Task AddAsync(Actor actor); // Burası VT ye kayıt eklemek(Actor tablosuna) için

        //Task UpdateAsync(int id,Actor actor); // Burası VT deki ilgili id kaydını güncellemek için

        //void DeleteAsync(int id); // Burası VTdeki tablodan kayıt silmek için

    }
}
