using System.Collections.Generic;
using System.Linq;
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

        public List<ReservationOutput> Reserve(List<ReservationInput> reservations)
        {
            var mappedItems =  reservations.Select(reservationInput => _database.Map(reservationInput)).ToList();

            return _database.InStock(mappedItems);
        }
    }
}
