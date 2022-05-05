using BEChallenge.CrossCutting.Exceptions;
using BEChallenge.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BEChallenge.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Members

        private readonly DbSet<TEntity> dbSet;

        #endregion

        #region Constructors

        public Repository(BEChallengeDbContext dbContext)
        {
            Argument.ThrowIfNull(() => dbContext);
            this.dbSet = dbContext.Set<TEntity>();
        }

        #endregion

        #region Methods

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.dbSet.AddRange(entities);
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet.AsQueryable();
        }

        public IQueryable<TEntity> AllAsNoTracking()
        {
            return this.dbSet.AsNoTracking();
        }

        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this.dbSet.AsQueryable<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Remove(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.dbSet.RemoveRange(entities);
        }

        #endregion
    }
}