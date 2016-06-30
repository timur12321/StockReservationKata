using StockKata.Inputs;

namespace StockKata
{
    public interface IDatabase
    {
        ReservationOutput Map(ReservationInput reservationInput);
    }
}
