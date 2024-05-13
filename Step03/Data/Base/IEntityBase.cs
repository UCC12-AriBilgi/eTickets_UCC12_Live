namespace eTickets.Data.Base
{
    // Tüm modellerde Id alanı ortak olduğu için hepsinin kullanabileceği bir Interface

    public interface IEntityBase
    {
        int Id { get; set; }
    }
}
