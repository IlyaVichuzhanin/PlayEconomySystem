using Microsoft.EntityFrameworkCore.Metadata;
using Mango.Services.CouponAPI.Entities;
using Mango.Services.CouponAPI.Models.DTOs;

namespace Mango.Services.CouponAPI.Converters;

public interface IConverter<TModel, TEntity>
    where TModel : IDto
    where TEntity : IEntity
{
    TModel? ConvertToDto(TEntity? entity);
    TEntity ConvertToEntity(TModel model);
}