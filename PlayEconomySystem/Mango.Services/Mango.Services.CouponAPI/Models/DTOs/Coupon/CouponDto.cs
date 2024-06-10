using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models.DTOs.Coupon

{
    public class CouponDto : BaseDto
    {
        public CouponDto(Guid? id, string couponCode, double discountAmount, int minAmount) : base(id)
        {
            Id=id;
            CouponCode = couponCode;
            DiscountAmount = discountAmount;
            MinAmount = minAmount;
        }

        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }


    }
}
