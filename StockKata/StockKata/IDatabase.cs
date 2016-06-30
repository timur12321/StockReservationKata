using System.Collections.Generic;
using StockKata.Inputs;

namespace StockKata
{
    public interface IDatabase
    {
        ReservationOutput Map(ReservationInput reservationInput);
        List<ReservationOutput> InStock(List<ReservationOutput> mappedItems);
    }
}
