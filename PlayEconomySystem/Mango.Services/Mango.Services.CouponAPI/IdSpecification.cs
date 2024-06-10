using Mango.Services.CouponAPI.Entities;
using Mango.Services.CouponAPISpecification;

namespace Mango.Services.CouponAPI
{
    public class IdSpecification<TEntity, TPrimaryKey> : ExpressionSpecification<TEntity>
        where TEntity : class, IEntity
    {
        public IdSpecification(TPrimaryKey id) : base(e => Equals(e.Id, id))
        {

        }
    }
}
