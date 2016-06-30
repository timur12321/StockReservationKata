using System.Collections.Generic;
using System.Linq;
using StockKata;
using StockKata.Inputs;

namespace StockKataTests
{
    public class DatabaseMock : IDatabase
    {
        readonly Dictionary<string, string> _skuDictionary = new Dictionary<string, string> {{ "ABC1", "987F" }, { "ABC2", "73E0" }, { "DEF4", "92BA" }, { "HAB2", "A37F" } };
        readonly Dictionary<string, string> _warehouseDictionary = new Dictionary<string, string> {{ "France", "FC04" }, { "Germany", "FC04" }, { "UK", "FC01" }, { "ROI", "FC01" }, { "US", "FC03" } };  
        public List<ReservationOutput> InStocklist = new List<ReservationOutput>();

        public ReservationOutput Map(ReservationInput reservationInput)
        {
            return new ReservationOutput() {Sku = _skuDictionary[reservationInput.Variant], WarehouseId = _warehouseDictionary[reservationInput.Region] };
        }

        public List<ReservationOutput> InStock(List<ReservationOutput> mappedItems)
        {
            var results = new List<ReservationOutput>();

            foreach (var item in mappedItems)
            {
                var instock = InStocklist.Select(x => x.Sku == item.Sku && x.WarehouseId == item.WarehouseId);
                if (instock.Any())
                    results.Add(item);
            }

            return results;
        }
    }
}
