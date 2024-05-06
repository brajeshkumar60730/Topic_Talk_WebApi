using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TopicTalks.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsync(long id);
        Task<IEnumerable<TEntity>> GetAsync();

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);
        Task AddAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
    }
}
