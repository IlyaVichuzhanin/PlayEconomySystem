using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models.Coupon
{
    public class CouponDto : BaseDto
    {
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
