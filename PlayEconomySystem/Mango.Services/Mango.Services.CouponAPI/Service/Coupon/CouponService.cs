using Mango.Services.CouponAPI.Converters;
using Mango.Services.CouponAPI.Models.DTOs.Coupon;
using Mango.Services.CouponAPI.Repositories;
using Mango.Services.CouponAPI.Service.Coupon;

namespace Mango.Services.CouponAPI.Service.Item
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IConverter<CouponDto, Services.CouponAPI.Entities.Coupon> _itemConverter;

        public CouponService(ICouponRepository itemRepository, IConverter<CouponDto, Services.CouponAPI.Entities.Coupon> itemConverter)
        {
            _couponRepository = itemRepository;
            _itemConverter = itemConverter;
        }
        public async Task<CouponDto> UpdateAsync(CouponDto coupon)
        {
            var result = await _couponRepository.UpdateAsync(coupon);
            return result;
        }

        public async Task<CouponDto> CreateAsync(CouponDto coupon)
        {
            var result = await _couponRepository.AddAsync(coupon);
            return result;
        }

        public void Delete(Guid? id)
        {
            _couponRepository.Delete(id);
        }

        public async Task<CouponDto> GetAsync(Guid? id)
        {
            var item = await _couponRepository.GetByIdAsync(id);
            return item;
        }

        public async Task<IEnumerable<CouponDto>> GetAllAsync()
        {
            var item = await _couponRepository.GetAllAsync();
            return item;
        }

    }
}
