using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using deech.me.data.abstractions;

namespace deech.me.logic.abstractions
{
    public interface IReadDataService<TEntity> where TEntity : IReadEntity
    {
        void SetIncludeFunc(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetMultiple(Expression<Func<TEntity, bool>> predicate);
    }
}