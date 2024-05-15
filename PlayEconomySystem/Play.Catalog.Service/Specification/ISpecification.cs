namespace Play.Catalog.Service.Specification;

public interface ISpecification<in T>
{
    bool IsSatisfiedBy(T entity);
}
