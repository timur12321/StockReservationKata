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

        [SetUp]
        public void setup()
        {
            _stock = new Stock(new DatabaseMock());
        }

        [Test]
        public void AcceptReservationInput()
        {
            _stock.Reserve(new List<ReservationInput>());
        }

        [Test]
        public void ReturnListOfReservationOuputs()
        {
            var results = _stock.Reserve(new List<ReservationInput>());
            Assert.AreEqual(new List<ReservationOutput>(), results);
        }

        [Test]
        public void ReturnSkuWhenGivenVariant()
        {
            var results = _stock.Reserve(new List<ReservationInput> { new ReservationInput { Variant = "ABC1", Region = "France" } });
            Assert.AreEqual("987F", results[0].Sku);
        }
    }
}
