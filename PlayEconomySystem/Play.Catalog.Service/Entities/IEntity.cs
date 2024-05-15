namespace Play.Catalog.Service.Entities;

public interface IEntity<TPrimaryKey>
{
    TPrimaryKey? Id { get; set; }
}

public interface IEntity : IEntity<Guid?>
{
} 