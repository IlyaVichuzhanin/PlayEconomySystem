using Microsoft.EntityFrameworkCore;
using Mango.Services.CouponAPI.Converters;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models.DTOs;
using Mango.Services.CouponAPI.Entities;

namespace Mango.Services.CouponAPI.Repositories.Implementations
{
    public abstract class AbstractRepository<TModel, TEntity> : IRepository<TModel>
    where TModel : class, IDto
    where TEntity : class, IEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly IConverter<TModel, TEntity> _converter;
        protected IQueryable<TEntity> DbQuery => DbSet.AsNoTracking().IgnoreAutoIncludes();

        public AbstractRepository(AppDbContext context, IConverter<TModel, TEntity> converter)
        {
            _context = context;
            _converter = converter;
            DbSet = context.Set<TEntity>();
        }

        public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<TModel?> GetByIdAsync(Guid? id, CancellationToken cancellationToken = default)
            => _converter.ConvertToDto(await DbQuery.FirstOrDefaultAsync(new IdSpecification<TEntity, Guid?>(id), cancellationToken));

        public async Task<IReadOnlyCollection<TModel>> GetAllAsync(CancellationToken cancellationToken = default)
            => (await DbQuery
                .ToArrayAsync(cancellationToken)).Select(x => _converter.ConvertToDto(x)).ToArray();

        public async Task<TModel> AddAsync(TModel model, CancellationToken cancellationToken = default)
        {
            var entryEntity = await DbSet.AddAsync(_converter.ConvertToEntity(model), cancellationToken);
            await SaveChangeAsync(cancellationToken);
            return _converter.ConvertToDto(entryEntity.Entity);
        }

        public async Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default)
        {
            var newEntity = _converter.ConvertToEntity(model);
            var entity = DbSet.Local.FirstOrDefault(new IdSpecification<TEntity, Guid?>(newEntity.Id));
            if (entity is null)
            {
                entity = newEntity;
                DbSet.Update(entity);
            }
            else
            {
                _context.Entry(entity).CurrentValues.SetValues(newEntity);
            }

            await SaveChangeAsync(cancellationToken);
            return _converter.ConvertToDto(entity);
        }

        public async Task Delete(Guid? id, CancellationToken cancellationToken)
        {
            DbSet.Remove(_converter.ConvertToEntity(await GetByIdAsync(id)));
            await SaveChangeAsync(cancellationToken);
        }
    }
}
