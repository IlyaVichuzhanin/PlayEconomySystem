using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal;
using Mango.Services.CouponAPI.Converters;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models.DTOs.Coupon;
using Mango.Services.CouponAPI.Entities;

namespace Mango.Services.CouponAPI.Repositories.Implementations
{
    public class CouponRepository : AbstractRepository<CouponDto, Coupon>, ICouponRepository
    {
        public CouponRepository(AppDbContext context, IConverter<CouponDto, Coupon> converter) : base(context, converter)
        {
        }
    }
}
