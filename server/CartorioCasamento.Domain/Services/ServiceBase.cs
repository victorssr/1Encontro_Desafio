using CartorioCasamento.Domain.Interfaces.Repositories;
using CartorioCasamento.Domain.Interfaces.Services;
using CartorioCasamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CartorioCasamento.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }


        #region Consults

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _repositoryBase.GetById(id);
        }

        public virtual async Task<TEntity> FindAsNoTracking(int id)
        {
            return await _repositoryBase.FindAsNoTracking(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _repositoryBase.GetAll();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repositoryBase.Find(predicate);
        }

        #endregion

        #region Inputs

        public virtual async Task Add(TEntity entity)
        {
            await _repositoryBase.Add(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            await _repositoryBase.Update(entity);
        }

        public virtual async Task Remove(int id)
        {
            await _repositoryBase.Remove(id);
        }

        public async Task RemoveInScale(List<TEntity> entities)
        {
            await _repositoryBase.RemoveInScale(entities);
        }

        #endregion

        public async Task<int> SaveChanges()
        {
            return await _repositoryBase.SaveChanges();
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }
    }
}
