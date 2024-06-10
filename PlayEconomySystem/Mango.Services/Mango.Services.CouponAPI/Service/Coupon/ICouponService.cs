using Mango.Services.CouponAPI.Models.DTOs.Coupon;

namespace Mango.Services.CouponAPI.Service.Coupon
{
    public interface ICouponService
    {
        Task<CouponDto> UpdateAsync(CouponDto? id);
        Task<CouponDto> CreateAsync(CouponDto itemDto);
        void Delete(Guid? id);
        Task<CouponDto> GetAsync(Guid? id);
        Task<IEnumerable<CouponDto>> GetAllAsync();
    }
}
