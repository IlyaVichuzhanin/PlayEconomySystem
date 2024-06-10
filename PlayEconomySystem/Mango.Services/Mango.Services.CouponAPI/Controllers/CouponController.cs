using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models.DTOs;
using Mango.Services.CouponAPI.Models.DTOs.Coupon;
using Mango.Services.CouponAPI.Entities;


namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _db;
        private IMapper _mapper;
        private ResponseDto _response = new ResponseDto();

        public CouponController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        private static readonly List<CouponDto> _items = new List<CouponDto>
        {
            new CouponDto(Guid.NewGuid(), "SYH", 0.23, 25),
            new CouponDto(Guid.NewGuid(), "DYD", 0.69, 20),
            new CouponDto(Guid.NewGuid(), "BNH", 0.58, 15)
        };

        [HttpGet, Route("GetAllCoupons")]
        public async Task<ResponseDto> GetAll()
        {
            try
            {
                IEnumerable<Coupon> items = await _db.Coupons.ToListAsync();
                IEnumerable<CouponDto> itemsDto = _mapper.Map<IEnumerable<CouponDto>>(items);
                _response.Result=itemsDto;
                _response.IsSuccess=true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess=false;
                _response.Message=ex.Message;
            }
            return _response;
        }

        [HttpGet, Route("GetById/{id}")]
        public async Task<ResponseDto> GetById(Guid id)
        {
            try
            {
                var item = await _db.Coupons.FirstOrDefaultAsync(item=>item.Id==id);
                _response.Result = item;
            }
            catch (ArgumentException ex)
            {
                _response.IsSuccess= false;
                _response.Message=ex.Message;
            }
            return _response;
        }

        [HttpGet, Route("GetByName/{couponCode}")]
        public async Task<ResponseDto> GetByName(string couponCode)
        {
            try
            {
                var item = await _db.Coupons.FirstOrDefaultAsync(item => item.CouponCode == couponCode);
                _response.Result = item;
            }
            catch (ArgumentException ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost, Route("CreateCoupon")]
        public async Task<ResponseDto> Post([FromBody] CreateCouponDto createCouponDto)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(createCouponDto);
                await _db.Coupons.AddAsync(coupon);
                await _db.SaveChangesAsync();
                _response.Result = coupon;
            }
            catch (ArgumentException ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut, Route("UpdateCoupon")]
        public async Task<ResponseDto> Put([FromBody] UpdateCouponDto updateCouponDto)
        {
            try
            {
                var item = await _db.Coupons.FirstOrDefaultAsync(item => item.Id == updateCouponDto.Id);
                item.CouponCode=updateCouponDto.CouponCode;
                item.DiscountAmount=updateCouponDto.DiscountAmount;
                item.MinAmount=updateCouponDto.MinAmount;
                _db.Coupons.Update(item);
                await _db.SaveChangesAsync();
                _response.Result = item;
            }
            catch (ArgumentException ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete, Route("DeleteCoupon/{id}")]
        public async Task<ResponseDto> Delete(Guid id)
        {
            try
            {
                var itemDto = await _db.Coupons.FirstOrDefaultAsync(item => item.Id == id);
                _db.Coupons.Remove(itemDto);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


    }
}
