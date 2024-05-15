namespace Play.Catalog.Service.Models.DTOs;

public interface IDto<TPrimaryKey>
{
    TPrimaryKey? Id { get; set; }
}

public interface IDto : IDto<Guid?>
{
}