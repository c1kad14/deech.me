using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using deech.me.data.abstractions;
using deech.me.data.context;
using deech.me.logic.abstractions;

namespace deech.me.logic.services
{
    public class ReadDataService<TEntity> : IReadDataService<TEntity> where TEntity : class, IReadEntity
    {
        protected readonly DbContextOptions dbContextOptions;

        public ReadDataService(DbContextOptions dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        protected Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc;

        public void SetIncludeFunc(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc)
        {
            this.includeFunc = includeFunc;
        }

        public List<TEntity> GetMultiple(Expression<Func<TEntity, bool>> predicate)
        {
            using var context = new DeechMeDataContext(this.dbContextOptions);
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            if (includeFunc != null)
                query = includeFunc(query);

            return query.ToList();
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate)
        {
            using var context = new DeechMeDataContext(this.dbContextOptions);
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (predicate != null)
                query = query.Where(predicate);

            if (includeFunc != null)
                query = includeFunc(query);

            return query.FirstOrDefault();
        }
    }
}