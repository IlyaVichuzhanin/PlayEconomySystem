namespace Mango.Web.Models;

public interface IDto<TPrimaryKey>
{
    TPrimaryKey? Id { get; set; }
}

public interface IDto : IDto<Guid?>
{
}