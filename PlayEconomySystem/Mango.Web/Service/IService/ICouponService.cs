using Mango.Services.CouponAPI.Models.DTOs;
using Mango.Web.Models.Coupon;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(Guid? id);
        Task<ResponseDto?> GetCouponByNameAsync(string name);
        Task<ResponseDto?> CreateCouponAsync(CreateCouponDto createCouponDto);
        Task<ResponseDto?> UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<ResponseDto?> DeleteCouponAsync(Guid? id);
    }
}
