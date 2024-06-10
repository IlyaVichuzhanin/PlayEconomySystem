using AutoMapper;
using Mango.Services.CouponAPI.Entities;
using Mango.Services.CouponAPI.Models.DTOs.Coupon;

namespace Mango.Services.CouponAPIMapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
                config.CreateMap<CreateCouponDto, Coupon>();
                config.CreateMap<UpdateCouponDto, Coupon>();
            });
            return mappingConfig;
        }
    }
}
