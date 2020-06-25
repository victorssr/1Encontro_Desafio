using CartorioCasamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : EntityBase
    {
        #region Consults

        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> FindAsNoTracking(int id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Inputs

        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(int id);
        Task RemoveInScale(List<TEntity> entities);
        Task<int> SaveChanges();

        #endregion
    }
}
