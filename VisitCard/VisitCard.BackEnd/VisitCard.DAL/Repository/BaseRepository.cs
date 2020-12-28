using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitCard.DAL.Context;
using VisitCard.DAL.Interfaces;

namespace VisitCard.DAL.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly RepositoryContext Context;
        private readonly DbSet<T> _set;

        protected BaseRepository(RepositoryContext repositoryContext)
        {
            Context = repositoryContext;
            _set = repositoryContext.Set<T>();
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filter) => 
            await _set.FirstOrDefaultAsync(filter);
        
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> condition) =>
            await _set.AnyAsync(condition);
        
        public async Task CreateAsync(T entity) => await _set.AddAsync(entity);

        public void Delete(T entity) => _set.Remove(entity);

        public void Update(T entity) => _set.Update(entity);
    }
}