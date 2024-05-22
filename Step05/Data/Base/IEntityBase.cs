namespace eTickets.Data.Base
{

    public interface IEntityBase
    {
        //Herbir modelde ortak olan Id bilgisini bir interface çektik
        int Id { get; set; }
    }
}
