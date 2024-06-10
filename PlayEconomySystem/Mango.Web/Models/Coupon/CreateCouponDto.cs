using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models.Coupon
{
    public class CreateCouponDto
    {
        //public CreateCouponDto(string couponCode, double discountAmount, int minAmount)
        //{
        //    CouponCode = couponCode;
        //    DiscountAmount = discountAmount;
        //    MinAmount = minAmount;
        //}

        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
