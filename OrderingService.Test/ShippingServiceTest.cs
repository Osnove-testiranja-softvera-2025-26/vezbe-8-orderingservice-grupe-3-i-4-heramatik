using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OTS2023_V9;

namespace OrderingService.Test
{
    [TestFixture]
    internal class ShippingServiceTest
    {
        private ShippingService shippingService;

        [SetUp]
        public void SetUp()
        {
            shippingService = new ShippingService();
        }

        [Test]
        public void CalculateShippingCost_InternationalStandardShipping_ReturnsDiscountedPrice()
        {
            double result = shippingService.CalculateShippingCost(
                1000,
                50,
                20,
                true,
                10,
                ShippingType.Standard);

            Assert.AreEqual(1540.0, result);
        }


        [Test]
        public void CalculateShippingCost_InternationalWithSmallQuantity_ReturnsRegularPrice()
        {
            double result = shippingService.CalculateShippingCost(
                1000,
                50,
                20,
                true,
                9,
                ShippingType.Standard);

            Assert.AreEqual(2050.0, result);
        }

        [Test]
        public void CalculateShippingCost_DistanceExactly2000_ReturnsRegularPrice()
        {
            double result = shippingService.CalculateShippingCost(
                2000,
                50,
                20,
                true,
                10,
                ShippingType.Standard);

            Assert.AreEqual(4050.0, result);
        }

        [Test]
        public void CalculateShippingCost_OvernightWeight30_ReturnsDiscountedPrice()
        {
            double result = shippingService.CalculateShippingCost(
                1000,
                50,
                30,
                true,
                10,
                ShippingType.Overnight);

            Assert.AreEqual(1540.0, result);
        }

        [Test]
        public void CalculateShippingCost_StandardDomesticOrder_ReturnsDiscount()
        {
            double result = shippingService.CalculateShippingCost(
                100,
                200,
                20,
                false,
                10,
                ShippingType.Standard);

            Assert.AreEqual(0.0, result);
        }
    }
}
