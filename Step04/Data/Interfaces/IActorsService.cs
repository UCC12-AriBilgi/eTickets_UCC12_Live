using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Interfaces
{
    // Burası bir sözleşme metni/yönerge gibi düşünülürse...Yapacağın servis içeriğinde bunlar olacaktır tanımlarını yaptığımız yer. Herhangi bir kod parçası yok. Kodlar esas Service modüllerinde olacak.

    public interface IActorsService : IEntityBaseRepository<Actor>
    {

    }
}
