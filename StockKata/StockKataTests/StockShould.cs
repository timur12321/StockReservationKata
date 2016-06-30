using System.Collections.Generic;
using NUnit.Framework;
using StockKata;
using StockKata.Inputs;

namespace StockKataTests
{
    [TestFixture]
    class StockShould
    {
        private Stock _stock;
        private DatabaseMock _dbMock;

        [SetUp]
        public void Setup()
        {
            _dbMock = new DatabaseMock();
            _stock = new Stock(_dbMock);
        }

        [Test]
        public void ReturnSingleReservationOutputWhenGivenReservationInput()
        {
            _dbMock.InStocklist = new List<ReservationOutput>() {new ReservationOutput() { Sku = "987F",WarehouseId = "FC04" } };
            var results = _stock.Reserve(new List<ReservationInput> { new ReservationInput { Variant = "ABC1", Region = "France" } });
            Assert.AreEqual("987F", results[0].Sku);
            Assert.AreEqual("FC04", results[0].WarehouseId);
        }

        [Test]
        public void ReturnMutipleReservationOutputWhenGivenReservationInput()
        {
            _dbMock.InStocklist = new List<ReservationOutput>()
            {
                new ReservationOutput() { Sku = "987F", WarehouseId = "FC04" },
                new ReservationOutput() { Sku = "73E0", WarehouseId = "FC01" }
            };

            var results = _stock.Reserve(new List<ReservationInput>
            {
                new ReservationInput { Variant = "ABC1", Region = "France" } ,
                new ReservationInput { Variant = "ABC2", Region = "UK"}
            });

            Assert.AreEqual("987F", results[0].Sku);
            Assert.AreEqual("FC04", results[0].WarehouseId);
            Assert.AreEqual("73E0", results[1].Sku);
            Assert.AreEqual("FC01", results[1].WarehouseId);
        }

        [Test]
        public void NotReturnSkuWhenOutOfStock()
        {
            var results = _stock.Reserve(new List<ReservationInput> { new ReservationInput { Variant = "HAB2", Region = "France" } });
            Assert.IsEmpty(results);
        }

    }
}
