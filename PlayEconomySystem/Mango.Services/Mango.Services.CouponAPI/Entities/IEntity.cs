namespace Mango.Services.CouponAPI.Entities;

public interface IEntity<TPrimaryKey>
{
    TPrimaryKey? Id { get; set; }
}

public interface IEntity : IEntity<Guid?>
{
} 