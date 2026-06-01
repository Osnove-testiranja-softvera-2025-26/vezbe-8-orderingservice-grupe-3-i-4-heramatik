using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_V9.Services.Fakes
{
    internal class FakeCouponService
    {
        public FakeCouponService Coupon { get; set; }
        public Guid UsedCouponId { get; set; }
        public InvalidCouponException invalidCouponExceptionToThrow { get; set; }

        public FakeCouponService GetCouponById(Guid id)
        {
            return Coupon;
        }


        public void UseCoupon(Guid id)
        {
            if (InvalidCouponExceptionToThrow != null)
            {
                throw InvalidCouponExceptionToThrow;
            }

            UsedCouponId = id;
        }
    }
}

