using System.Linq.Expressions;

namespace Play.Catalog.Service.Specification;

public class FalseSpecification<T> : ExpressionSpecification<T>
{
    protected internal FalseSpecification() : base(_ => false)
    {
    }
}