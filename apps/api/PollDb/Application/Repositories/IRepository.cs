using PollDb.Domain.Entities;

namespace PollDb.Application.Repositories;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<IList<TEntity>> GetAll();
    Task<TEntity> Create(TEntity entity);
}
