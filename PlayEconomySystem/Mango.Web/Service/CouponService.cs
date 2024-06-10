using Mango.Services.CouponAPI.Models.DTOs;
using Mango.Web.Models;
using Mango.Web.Models.Coupon;
using Mango.Web.Service.IService;
using Mango.Web.Utility;


namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService=baseService; 
        }
        public async Task<ResponseDto?> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = createCouponDto,
                Url = SD.CouponAPIBase + "api/Coupon/CreateCoupon"
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(Guid? id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + "api/Coupon/DeleteCoupon/" + id + "/"
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "api/Coupon/GetAllCoupons"
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(Guid? id)
        {

            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "api/Coupon/GetById/" + id +"/"
            });
        }

        public async Task<ResponseDto?> GetCouponByNameAsync(string name)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "api/Coupon/GetByName/" + name
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data=updateCouponDto,
                Url = SD.CouponAPIBase + "api/Coupon/UpdateCoupon/"
            });
        }
    }
}
