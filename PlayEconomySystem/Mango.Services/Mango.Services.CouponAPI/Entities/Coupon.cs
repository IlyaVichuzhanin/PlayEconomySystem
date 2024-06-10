using System.ComponentModel.DataAnnotations;

namespace Mango.Services.CouponAPI.Entities
{
    public class Coupon : BaseEntity

    {

        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
