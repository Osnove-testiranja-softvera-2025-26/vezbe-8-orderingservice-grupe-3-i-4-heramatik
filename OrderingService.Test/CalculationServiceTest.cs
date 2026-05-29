using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Test
{
    
    internal class CalculationServiceTest
    {
        private FakeOrderService fakeOrderService;
        private FakeCouponService fakeCouponService;
        private FakeLoggerService fakeLoggerService;
        private CalculationService calculationService;

        [SetUp]
        public void SetUp()
        {
            fakeOrderService = new FakeOrderService();
            fakeCouponService = new FakeCouponService();
            fakeLoggerService = new FakeLoggerService();
            calculationService = new CalculationService(fakeOrderService, fakeCouponService);
            calculationService.LoggerService = fakeLoggerService;
        }

        [TestCase(5, 400, 300, false, true)]
        [TestCase(-3, 400, 300, false, false)] //expirationDateHours in the past
        [TestCase(5, 200, 300, false, false)] // orderTotal < couponMinimalRequiredOrder
        [TestCase(5, 400, 300, true, false)] // couponUsed = true

        public void CheckCouponValidity_CouponValid_Success(int expirationDateHours, int orderTotal, int couponMinimalRequiredOrderTotal, bool couponUsed, bool expected)
        {
            fakeOrderService.Orders = new List<Order>
            {
                new Order
                {
                    Total = orderTotal
                }
            };
            fakeCouponService.Coupon = new Coupon
            {
                ExpirationDate = DateTime.Now.AddHours(expirationDateHours),
                MinimalRequiredOrderTotal = couponMinimalRequiredOrderTotal,
                User = couponUsed
            };
            bool actual = calculationService.CheckCouponValidity(Guid.NewGuid(), Guid.NewGuid());

            Assert.AreEqual(expected, actual);
        }
        public void CalculateUserDiscount_Delivered(int userName)
        {
            fakeOrderService.Orders = new List<Order>
            {
                new Order
                {
                    Status = Status.Delivered
                },
                new Order
                {
                    Status = Status.Delivered
                },
                new Order
                {
                    Status = Status.Delivered
                },
                new Order
                {
                    Status = Status.Delivered
                },
                new Order
                {
                    Status = Status.Rejected
                }
            };
            double actual = calculationService.CalculateUserDiscount(Guid.NewGuid());

            Assert.AreEqual(0.05, actual);
        }
    }
}
