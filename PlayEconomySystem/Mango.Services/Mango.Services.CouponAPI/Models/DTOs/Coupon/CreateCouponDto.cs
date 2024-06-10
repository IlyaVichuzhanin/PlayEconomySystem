using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Models.DTOs.Coupon
{
    public class CreateCouponDto
    {
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
