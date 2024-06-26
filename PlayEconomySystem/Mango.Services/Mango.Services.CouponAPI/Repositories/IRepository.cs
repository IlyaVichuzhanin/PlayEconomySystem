using Mango.Services.CouponAPI.Models.DTOs;

namespace Mango.Services.CouponAPI.Repositories;

public interface IRepository<TModel>
    where TModel: class, IDto
{
    public Task SaveChangeAsync(CancellationToken cancellationToken = default);
    public Task<TModel?> GetByIdAsync(Guid? id, CancellationToken cancellationToken = default);
    public Task<IReadOnlyCollection<TModel>> GetAllAsync(CancellationToken cancellationToken = default);
    public Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default);
    public Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default);
    public Task Delete(Guid? id, CancellationToken cancellationToken = default);
}