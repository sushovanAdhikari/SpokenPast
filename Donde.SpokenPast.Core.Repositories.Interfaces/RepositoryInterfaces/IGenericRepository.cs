using Donde.SpokenPast.Core.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Donde.SpokenPast.Core.Repositories.Interfaces.RepositoryInterfaces
{
    //public interface IGenericRepository<TEntity> where TEntity : class
    //{
    //    IQueryable<TEntity> GetAll();

    //    Task<TEntity> GetByIdAsync(Guid id);

    //    Task<TEntity> CreateAsync(TEntity entity);

    //    Task<TEntity> UpdateAsync(Guid id, TEntity entity);
    //}

    public interface IGenericRepository
    {
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IDondeModel;

        Task<TEntity> GetByIdAsync<TEntity>(Guid id) where TEntity : class, IDondeModel;

        Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class, IDondeModel;

        Task<TEntity> UpdateAsync<TEntity>(Guid id, TEntity entity) where TEntity : class, IDondeModel;
    }
}

