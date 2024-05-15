using Microsoft.EntityFrameworkCore.Metadata;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Models.DTOs;

namespace Play.Catalog.Service.Converters;

public interface IConverter<TModel, TEntity>
    where TModel : IDto
    where TEntity : IEntity
{
    TModel? ConvertToDto(TEntity? entity);
    TEntity ConvertToEntity(TModel model);
}