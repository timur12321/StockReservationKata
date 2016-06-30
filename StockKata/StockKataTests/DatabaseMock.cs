using StockKata;
using StockKata.Inputs;

namespace StockKataTests
{
    public class DatabaseMock : IDatabase
    {
        public ReservationOutput Map(ReservationInput reservationInput)
        {
            return new ReservationOutput() {Sku = "987F", WarehouseId = ""};
        }
    }
}
