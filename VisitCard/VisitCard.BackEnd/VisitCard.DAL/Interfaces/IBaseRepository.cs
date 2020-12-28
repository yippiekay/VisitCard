using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VisitCard.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> ExistsAsync(Expression<Func<T, bool>> condition);
        Task<T> FindOneAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}