using System.Collections.Generic;
using StockKata.Inputs;

namespace StockKata
{
    public class Stock
    {
        private IDatabase _database;

        public Stock(IDatabase database)
        {
            _database = database;
        }

        public List<ReservationOutput> Reserve(List<ReservationInput> list)
        {
            var reservedStock = new List<ReservationOutput>();

            foreach (var reservationInput in list)
            {
                reservedStock.Add(_database.Map(reservationInput));
            }

            return reservedStock;
        }
    }
}
