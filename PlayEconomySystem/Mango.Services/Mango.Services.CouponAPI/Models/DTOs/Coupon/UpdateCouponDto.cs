using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models.DTOs.Coupon
{
    public class UpdateCouponDto : BaseDto
    {
        public UpdateCouponDto(Guid id, string couponCode, double discountAmount, int minAmount) : base(id)
        {
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
