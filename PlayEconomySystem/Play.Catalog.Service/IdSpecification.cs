using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Specification;

namespace Play.Catalog.Service
{
    public class IdSpecification<TEntity, TPrimaryKey> : ExpressionSpecification<TEntity>
        where TEntity : class, IEntity
    {
        public IdSpecification(TPrimaryKey id) : base(e => Equals(e.Id, id))
        {

        }
    }
}
