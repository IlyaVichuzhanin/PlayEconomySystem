namespace Mango.Services.CouponAPI.Models.DTOs;

public interface IDto<TPrimaryKey>
{
    TPrimaryKey? Id { get; set; }
}

public interface IDto : IDto<Guid?>
{
}